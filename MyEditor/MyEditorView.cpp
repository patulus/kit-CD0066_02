
// MyEditorView.cpp: CMyEditorView 클래스의 구현
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS는 미리 보기, 축소판 그림 및 검색 필터 처리기를 구현하는 ATL 프로젝트에서 정의할 수 있으며
// 해당 프로젝트와 문서 코드를 공유하도록 해 줍니다.
#ifndef SHARED_HANDLERS
#include "MyEditor.h"
#endif

#include "MyEditorDoc.h"
#include "MyEditorView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMyEditorView

IMPLEMENT_DYNCREATE(CMyEditorView, CEditView)

BEGIN_MESSAGE_MAP(CMyEditorView, CEditView)
	// 표준 인쇄 명령입니다.
	ON_COMMAND(ID_FILE_PRINT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CEditView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CMyEditorView 생성/소멸

CMyEditorView::CMyEditorView() noexcept
{
	// TODO: 여기에 생성 코드를 추가합니다.

}

CMyEditorView::~CMyEditorView()
{
}

BOOL CMyEditorView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: CREATESTRUCT cs를 수정하여 여기에서
	//  Window 클래스 또는 스타일을 수정합니다.

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL);	// 자동 래핑을 사용합니다.

	return bPreCreated;
}


// CMyEditorView 인쇄

BOOL CMyEditorView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 기본적인 CEditView 준비
	return CEditView::OnPreparePrinting(pInfo);
}

void CMyEditorView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 기본 CEditView 시작 인쇄
	CEditView::OnBeginPrinting(pDC, pInfo);
}

void CMyEditorView::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 기본 CEditView 종료 인쇄
	CEditView::OnEndPrinting(pDC, pInfo);
}


// CMyEditorView 진단

#ifdef _DEBUG
void CMyEditorView::AssertValid() const
{
	CEditView::AssertValid();
}

void CMyEditorView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CMyEditorDoc* CMyEditorView::GetDocument() const // 디버그되지 않은 버전은 인라인으로 지정됩니다.
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMyEditorDoc)));
	return (CMyEditorDoc*)m_pDocument;
}
#endif //_DEBUG


// CMyEditorView 메시지 처리기
