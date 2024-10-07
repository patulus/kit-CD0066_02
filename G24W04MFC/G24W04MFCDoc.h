
// G24W04MFCDoc.h: CG24W04MFCDoc 클래스의 인터페이스
//


#pragma once


class CG24W04MFCDoc : public CDocument
{
//protected:
//	// Doc 클래스는 생성 후 계속 유지가 됨
//	// 새로 만들기 시 데이터가 초기화됨 => 새로 만들기에도 초기화 필요
//	CPoint Pos = CPoint(-100, -100); // 변수 선언 후 초기화! (OnNewDocument 함수에서)
//public:
//	CPoint getPos() {
//		return this->Pos;
//	}
//
//	void setPos(CPoint pos) {
//		this->Pos = pos;
//		SetModifiedFlag();
//	}
protected:
	CArray<CPoint, CPoint> Points;
public:
	int GetPointsCount() {
		return (int) this->Points.GetCount();
	}

	void AddPoint(CPoint p) {
		this->Points.Add(p);
		SetModifiedFlag();
	}

	CPoint GetPoint(int index) {
		return this->Points[index];
	}

	void RemoveLast() {
		if (Points.GetCount() > 0) {
			this->Points.RemoveAt(Points.GetCount() - 1);
			SetModifiedFlag();
		}
	}

protected: // serialization에서만 만들어집니다.
	CG24W04MFCDoc() noexcept;
	DECLARE_DYNCREATE(CG24W04MFCDoc)

// 특성입니다.
public:

// 작업입니다.
public:

// 재정의입니다.
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
#ifdef SHARED_HANDLERS
	virtual void InitializeSearchContent();
	virtual void OnDrawThumbnail(CDC& dc, LPRECT lprcBounds);
#endif // SHARED_HANDLERS

// 구현입니다.
public:
	virtual ~CG24W04MFCDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// 생성된 메시지 맵 함수
protected:
	DECLARE_MESSAGE_MAP()

#ifdef SHARED_HANDLERS
	// 검색 처리기에 대한 검색 콘텐츠를 설정하는 도우미 함수
	void SetSearchContent(const CString& value);
#endif // SHARED_HANDLERS
};
