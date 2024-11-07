
// CG24ShapeViewerView.cpp: CCG24ShapeViewerView 클래스의 구현
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS는 미리 보기, 축소판 그림 및 검색 필터 처리기를 구현하는 ATL 프로젝트에서 정의할 수 있으며
// 해당 프로젝트와 문서 코드를 공유하도록 해 줍니다.
#ifndef SHARED_HANDLERS
#include "CG24ShapeViewer.h"
#endif

#include "CG24ShapeViewerDoc.h"
#include "CG24ShapeViewerView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCG24ShapeViewerView

IMPLEMENT_DYNCREATE(CCG24ShapeViewerView, CView)

BEGIN_MESSAGE_MAP(CCG24ShapeViewerView, CView)
	// 표준 인쇄 명령입니다.
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_ERASEBKGND()
	ON_WM_MOUSEWHEEL()
END_MESSAGE_MAP()

// CCG24ShapeViewerView 생성/소멸

CCG24ShapeViewerView::CCG24ShapeViewerView() noexcept
{
	// TODO: 여기에 생성 코드를 추가합니다.

}

CCG24ShapeViewerView::~CCG24ShapeViewerView()
{
}

BOOL CCG24ShapeViewerView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: CREATESTRUCT cs를 수정하여 여기에서
	//  Window 클래스 또는 스타일을 수정합니다.

	return CView::PreCreateWindow(cs);
}

// CCG24ShapeViewerView 그리기

void CCG24ShapeViewerView::OnDraw(CDC* pDC)
{
	CCG24ShapeViewerDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 여기에 원시 데이터에 대한 그리기 코드를 추가합니다.
	CDC shpDC;
	shpDC.CreateCompatibleDC(pDC);
	CRect bbox;
	GetClientRect(&bbox);
	CBitmap shp;
	shp.CreateCompatibleBitmap(pDC, bbox.Width(), bbox.Height());
	CBitmap* backup = shpDC.SelectObject(&shp);
	shpDC.FillSolidRect(bbox, RGB(121, 133, 202));

	if (pDoc->IsReady() == TRUE)
	{
		RenderShape(&shpDC);
	}

	// 화면 전송
	pDC->BitBlt(0, 0, bbox.Width(), bbox.Height(), &shpDC, 0, 0, SRCCOPY);
	shpDC.SelectObject(backup);
}


// CCG24ShapeViewerView 인쇄

BOOL CCG24ShapeViewerView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 기본적인 준비
	return DoPreparePrinting(pInfo);
}

void CCG24ShapeViewerView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 인쇄하기 전에 추가 초기화 작업을 추가합니다.
}

void CCG24ShapeViewerView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 인쇄 후 정리 작업을 추가합니다.
}


// CCG24ShapeViewerView 진단

#ifdef _DEBUG
void CCG24ShapeViewerView::AssertValid() const
{
	CView::AssertValid();
}

void CCG24ShapeViewerView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CCG24ShapeViewerDoc* CCG24ShapeViewerView::GetDocument() const // 디버그되지 않은 버전은 인라인으로 지정됩니다.
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CCG24ShapeViewerDoc)));
	return (CCG24ShapeViewerDoc*)m_pDocument;
}
#endif //_DEBUG


// CCG24ShapeViewerView 메시지 처리기
void CCG24ShapeViewerView::RenderShape(CDC* pDC)
{
	CCG24ShapeViewerDoc* pDoc = GetDocument();

	srand(100); // 같은 색으로 출력하기 위해 고정
	int* part = NULL;
	CPoint* point = NULL;
	int n = pDoc->GetNextPolygon(&part, &point);

	while (n != 0)
	{
		CBrush paint(RGB(rand() % 128 + 127, rand() % 128 + 127, rand() % 128 + 127));
		CBrush* temp = pDC->SelectObject(&paint);
		pDC->PolyPolygon(point, part, n);
		pDC->SelectObject(temp);

		delete[] point;
		delete[] part;
		n = pDoc->GetNextPolygon(&part, &point);
	}

	pDoc->Rewind();
}

BOOL CCG24ShapeViewerView::OnEraseBkgnd(CDC* pDC)
{
	return TRUE;
}

BOOL CCG24ShapeViewerView::OnMouseWheel(UINT nFlags, short zDelta, CPoint pt)
{
	CCG24ShapeViewerDoc* pDoc = GetDocument();
	if (zDelta > 0)
	{
		pDoc->SetScale(pDoc->GetScale() * 1.1);
	}
	else
	{
		pDoc->SetScale(pDoc->GetScale() * 0.9);
	}

	Invalidate();
	return CView::OnMouseWheel(nFlags, zDelta, pt);
}