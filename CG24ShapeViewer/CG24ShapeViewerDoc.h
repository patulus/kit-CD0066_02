
// CG24ShapeViewerDoc.h: CCG24ShapeViewerDoc 클래스의 인터페이스
//


#pragma once


class CCG24ShapeViewerDoc : public CDocument
{
protected:
	CString Path;
	FILE* ShpFp = NULL;
	char* Buff = NULL;
	long Size = 0L;
	long Offset = 0L;
	double MbrX1 = 0., MbrY1 = 0., MbrX2 = 0., MbrY2 = 0.;
	double Scale = 1.;

	void ShowErrorAndCloseFile(CString msg)
	{
		fclose(ShpFp);
		ShpFp = NULL;
		AfxMessageBox(msg);
	}

	double ReadDouble()
	{
		double value = *(double*)(Buff + Offset);
		Offset += sizeof(double);
		return value;
	}
	
	int ReadInt()
	{
		int value = *(int*)(Buff + Offset);
		Offset += sizeof(int);
		return value;
	}

	void ReadBytes(char** dst, long size)
	{
		memcpy(*dst, Buff + Offset, size);
		Offset += size;
	}

	BOOL OpenShape(CString path);

public:
	BOOL IsReady() { return (ShpFp == NULL) ? FALSE : TRUE; }

	int GetNextPolygon(int** part, CPoint** point);
	void Rewind() { Offset = 100L;  }

	double GetX1() { return MbrX1; }
	double GetY1() { return MbrY1; }
	double GetX2() { return MbrX2; }
	double GetY2() { return MbrY2; }
	double GetScale() { return Scale; }
	void SetScale(double s) { if (s > 0) { Scale = s; } }

public:
	virtual BOOL OnOpenDocument(LPCTSTR lpszPathName);
	virtual void OnCloseDocument();

protected: // serialization에서만 만들어집니다.
	CCG24ShapeViewerDoc() noexcept;
	DECLARE_DYNCREATE(CCG24ShapeViewerDoc)

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
	virtual ~CCG24ShapeViewerDoc();
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
