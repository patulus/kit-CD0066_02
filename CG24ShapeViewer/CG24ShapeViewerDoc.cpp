
// CG24ShapeViewerDoc.cpp: CCG24ShapeViewerDoc 클래스의 구현
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS는 미리 보기, 축소판 그림 및 검색 필터 처리기를 구현하는 ATL 프로젝트에서 정의할 수 있으며
// 해당 프로젝트와 문서 코드를 공유하도록 해 줍니다.
#ifndef SHARED_HANDLERS
#include "CG24ShapeViewer.h"
#endif

#include "CG24ShapeViewerDoc.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CCG24ShapeViewerDoc

IMPLEMENT_DYNCREATE(CCG24ShapeViewerDoc, CDocument)

BEGIN_MESSAGE_MAP(CCG24ShapeViewerDoc, CDocument)
END_MESSAGE_MAP()


// CCG24ShapeViewerDoc 생성/소멸

CCG24ShapeViewerDoc::CCG24ShapeViewerDoc() noexcept
{
	// TODO: 여기에 일회성 생성 코드를 추가합니다.

}

CCG24ShapeViewerDoc::~CCG24ShapeViewerDoc()
{
}

BOOL CCG24ShapeViewerDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: 여기에 재초기화 코드를 추가합니다.
	// SDI 문서는 이 문서를 다시 사용합니다.

	return TRUE;
}




// CCG24ShapeViewerDoc serialization

void CCG24ShapeViewerDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: 여기에 저장 코드를 추가합니다.
	}
	else
	{
		// TODO: 여기에 로딩 코드를 추가합니다.
	}
}

#ifdef SHARED_HANDLERS

// 축소판 그림을 지원합니다.
void CCG24ShapeViewerDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
{
	// 문서의 데이터를 그리려면 이 코드를 수정하십시오.
	dc.FillSolidRect(lprcBounds, RGB(255, 255, 255));

	CString strText = _T("TODO: implement thumbnail drawing here");
	LOGFONT lf;

	CFont* pDefaultGUIFont = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	pDefaultGUIFont->GetLogFont(&lf);
	lf.lfHeight = 36;

	CFont fontDraw;
	fontDraw.CreateFontIndirect(&lf);

	CFont* pOldFont = dc.SelectObject(&fontDraw);
	dc.DrawText(strText, lprcBounds, DT_CENTER | DT_WORDBREAK);
	dc.SelectObject(pOldFont);
}

// 검색 처리기를 지원합니다.
void CCG24ShapeViewerDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// 문서의 데이터에서 검색 콘텐츠를 설정합니다.
	// 콘텐츠 부분은 ";"로 구분되어야 합니다.

	// 예: strSearchContent = _T("point;rectangle;circle;ole object;");
	SetSearchContent(strSearchContent);
}

void CCG24ShapeViewerDoc::SetSearchContent(const CString& value)
{
	if (value.IsEmpty())
	{
		RemoveChunk(PKEY_Search_Contents.fmtid, PKEY_Search_Contents.pid);
	}
	else
	{
		CMFCFilterChunkValueImpl *pChunk = nullptr;
		ATLTRY(pChunk = new CMFCFilterChunkValueImpl);
		if (pChunk != nullptr)
		{
			pChunk->SetTextValue(PKEY_Search_Contents, value, CHUNK_TEXT);
			SetChunkValue(pChunk);
		}
	}
}

#endif // SHARED_HANDLERS

// CCG24ShapeViewerDoc 진단

#ifdef _DEBUG
void CCG24ShapeViewerDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CCG24ShapeViewerDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CCG24ShapeViewerDoc 명령
BOOL CCG24ShapeViewerDoc::OnOpenDocument(LPCTSTR lpszPathName)
{
	if (!CDocument::OnOpenDocument(lpszPathName)) return FALSE;
	if (ShpFp != NULL) { fclose(ShpFp); ShpFp = NULL; }
	if (Buff != NULL) { delete[] Buff; Buff = NULL; }
	Size = 0L; Offset = 0L; Scale = 1.;
	MbrX1 = 0., MbrY1 = 0., MbrX2 = 0., MbrY2 = 0.;
	OpenShape(lpszPathName);
	return TRUE;
}

BOOL CCG24ShapeViewerDoc::OpenShape(CString str)
{
	// CStringA는 ASCII용 (참고로 CString은 CStringW로서 Unicode용)
	CStringA str2(str);
	const char* path = str2;

	fopen_s(&ShpFp, path, "rb");
	if (ShpFp == NULL)
	{
		AfxMessageBox(L"Error: 파일 오픈"); return FALSE;
	}

	int result = fseek(ShpFp, 32L, SEEK_SET);
	if (result != 0)
	{
		ShowErrorAndCloseFile(L"Error: 파일 오픈"); return FALSE;
	}

	int type; // Shape Type이 Polygon (5)인지 검사
	result = (int)fread(&type, sizeof(int), 1, ShpFp);
	if (result != 1)
	{
		ShowErrorAndCloseFile(L"Error: 파일 타입 읽기"); return FALSE;
	}
	if (type != 5)
	{
		ShowErrorAndCloseFile(L"Error: 지원되지 않는 타입"); return FALSE;
	}

	fseek(ShpFp, 0L, SEEK_END);
	Size = ftell(ShpFp);
	Buff = new char[Size];
	if (Buff == NULL)
	{
		ShowErrorAndCloseFile(L"Error: 메모리 할당"); return FALSE;
	}

	fseek(ShpFp, 0L, SEEK_SET);
	long sizeRead = (long)fread(Buff, sizeof(char), Size, ShpFp);
	if (Size != sizeRead)
	{
		delete[] Buff; Buff = NULL;
		ShowErrorAndCloseFile(L"Error: 파일 읽기"); return FALSE;
	}

	Offset = 36L;
	// Minimum Bounding Rectangle
	MbrX1 = ReadDouble(); MbrY1 = ReadDouble();
	MbrX2 = ReadDouble(); MbrY2 = ReadDouble();

	// Scale to FHD (1920 * 1080)
	Scale = 1920.F / fabs(MbrX2 - MbrX1);
	if (Scale > 1080. / fabs(MbrY2 - MbrY1))
	{
		Scale = 1080. / fabs(MbrY2 - MbrY1);
	}

	Rewind();
	return TRUE;
}

int CCG24ShapeViewerDoc::GetNextPolygon(int** part, CPoint** point)
{
	if (Offset >= Size) return 0;

	// Skip Record Header, Type, and Box
	Offset += sizeof(int) * 3 + sizeof(double) * 4;

	int numParts = ReadInt();
	int numPoints = ReadInt();

	*part = new int[numParts];
	ReadBytes((char**)part, numParts * sizeof(int));

	double* pts = new double[numPoints * 2];
	ReadBytes((char**)&pts, numPoints * 2 * sizeof(double));

	*point = new CPoint[numPoints];
	for (int i = 0; i < numPoints; i++)
	{
		(*point)[i].x = (long)((pts[i * 2] - MbrX1) * Scale);
		(*point)[i].y = (long)((MbrY2 - pts[i * 2 + 1]) * Scale);
	}
	for (int i = 0; i < numParts - 1; i++)
	{
		(*part)[i] = (*part)[i + 1] - (*part)[i];
	}
	(*part)[numParts - 1] = numPoints - (*part)[numParts - 1];
	delete[] pts;

	return numParts;
}

void CCG24ShapeViewerDoc::OnCloseDocument()
{
	if (ShpFp != NULL)
	{
		fclose(ShpFp); ShpFp = NULL;
	}
	if (Buff != NULL)
	{
		delete[] Buff; Buff = NULL;
	}
	CDocument::OnCloseDocument();
}