
// MyEditorView.h: CMyEditorView 클래스의 인터페이스
//

#pragma once


class CMyEditorView : public CEditView
{
protected: // serialization에서만 만들어집니다.
	CMyEditorView() noexcept;
	DECLARE_DYNCREATE(CMyEditorView)

// 특성입니다.
public:
	CMyEditorDoc* GetDocument() const;

// 작업입니다.
public:

// 재정의입니다.
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// 구현입니다.
public:
	virtual ~CMyEditorView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// 생성된 메시지 맵 함수
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // MyEditorView.cpp의 디버그 버전
inline CMyEditorDoc* CMyEditorView::GetDocument() const
   { return reinterpret_cast<CMyEditorDoc*>(m_pDocument); }
#endif

