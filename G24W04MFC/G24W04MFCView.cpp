
// G24W04MFCView.cpp: CG24W04MFCView 클래스의 구현
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS는 미리 보기, 축소판 그림 및 검색 필터 처리기를 구현하는 ATL 프로젝트에서 정의할 수 있으며
// 해당 프로젝트와 문서 코드를 공유하도록 해 줍니다.
#ifndef SHARED_HANDLERS
#include "G24W04MFC.h"
#endif

#include "G24W04MFCDoc.h"
#include "G24W04MFCView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CG24W04MFCView

IMPLEMENT_DYNCREATE(CG24W04MFCView, CView)

// + 배열을 만든다, 반복문을 돌며 현재 메시지를 처리할 수 있는 메시지 아이디를 찾는다, 그리고 그에 해당하는 함수를 실행
BEGIN_MESSAGE_MAP(CG24W04MFCView, CView)
	// 표준 인쇄 명령입니다.
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_LBUTTONDOWN()
	ON_WM_RBUTTONDOWN()
	ON_WM_MOUSEMOVE()
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

// CG24W04MFCView 생성/소멸

CG24W04MFCView::CG24W04MFCView() noexcept
{
	// TODO: 여기에 생성 코드를 추가합니다.

}

CG24W04MFCView::~CG24W04MFCView()
{
}

BOOL CG24W04MFCView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: CREATESTRUCT cs를 수정하여 여기에서
	//  Window 클래스 또는 스타일을 수정합니다.

	return CView::PreCreateWindow(cs);
}

// CG24W04MFCView 그리기

void CG24W04MFCView::OnDraw(CDC* pDC)
{
	CG24W04MFCDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: 여기에 원시 데이터에 대한 그리기 코드를 추가합니다.
	//------------------------------------ 메모리 DC에 쓰기
	CDC memDC;
	memDC.CreateCompatibleDC(pDC);

	CRect rect;
	GetClientRect(&rect);
	
	CBitmap bmp;
	bmp.CreateCompatibleBitmap(pDC, rect.Width(), rect.Height());

	CBitmap* old = memDC.SelectObject(&bmp);

	memDC.FillSolidRect(rect, RGB(255, 255, 255));
	//------------------------------------
	//CPoint p = pDoc->getPos();
	int n = pDoc->GetPointsCount();
	
	CPoint p;
	for (int i = 0; i < n; i++) {
		p = pDoc->GetPoint(i);
		//pDC->Ellipse(p.x - 30, p.y - 30, p.x + 30, p.y + 30);
		// 메모리 DC에 쓰기
		memDC.Ellipse(p.x - 30, p.y - 30, p.x + 30, p.y + 30);
	}
	//pDC->Ellipse(p.x - 30, p.y - 30, p.x + 30, p.y + 30);

	//------------------------------------ 화면에 보내기
	pDC->BitBlt(0, 0,
		rect.Width(), rect.Height(),
		&memDC,
		0, 0,
		SRCCOPY);

	memDC.SelectObject(old);
	//------------------------------------
}


// CG24W04MFCView 인쇄

BOOL CG24W04MFCView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 기본적인 준비
	return DoPreparePrinting(pInfo);
}

void CG24W04MFCView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 인쇄하기 전에 추가 초기화 작업을 추가합니다.
}

void CG24W04MFCView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: 인쇄 후 정리 작업을 추가합니다.
}


// CG24W04MFCView 진단

#ifdef _DEBUG
void CG24W04MFCView::AssertValid() const
{
	CView::AssertValid();
}

void CG24W04MFCView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CG24W04MFCDoc* CG24W04MFCView::GetDocument() const // 디버그되지 않은 버전은 인라인으로 지정됩니다.
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CG24W04MFCDoc)));
	return (CG24W04MFCDoc*)m_pDocument;
}
#endif //_DEBUG


// CG24W04MFCView 메시지 처리기

// 속성에서 메시지 관련 함수 추가 시 세 부분에 추가가 됨
// 잘못 만들었을 땐 BEGIN_MESSAGE_MAP, View.h, 아래 함수 부분을 없애야 함
void CG24W04MFCView::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.

	//CClientDC dc(this);
	//dc.Ellipse(point.x - 30, point.y - 30, point.x + 30, point.y + 30);
	
	// 데이터 변경
	CG24W04MFCDoc* pDoc = GetDocument();
	//pDoc->setPos(point);
	pDoc->AddPoint(point);
	// 화면 다시 그리기
	Invalidate();

	CView::OnLButtonDown(nFlags, point);
}

void CG24W04MFCView::OnRButtonDown(UINT nFlags, CPoint point)
{
	// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.

	CG24W04MFCDoc* pDoc = GetDocument();
	pDoc->RemoveLast();
	// 화면 다시 그리기
	Invalidate();

	CView::OnRButtonDown(nFlags, point);
}

void CG24W04MFCView::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.
	if (nFlags & MK_LBUTTON) {
		GetDocument()->AddPoint(point);
		Invalidate();
	}

	// 오버라이드 함수라 착각할 수 있으므로 주의
	// 오버라이드 함수는 재정의하면 옛날 함수와 오버라이드 함수 주소를 모두 가져서 관리돼야 함
	// 메시지는 배열에 특정 메시지가 정의돼 있으면 해당 메시지에 해당하는 함수를 호출해 메모리 사용을 최소화
	CView::OnMouseMove(nFlags, point);
}

BOOL CG24W04MFCView::OnEraseBkgnd(CDC* pDC)
{
	// TODO: 여기에 메시지 처리기 코드를 추가 및/또는 기본값을 호출합니다.

	//return CView::OnEraseBkgnd(pDC);
	return TRUE;
}
