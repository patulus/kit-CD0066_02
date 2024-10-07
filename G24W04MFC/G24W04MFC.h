
// G24W04MFC.h: G24W04MFC 애플리케이션의 기본 헤더 파일
//
#pragma once

#ifndef __AFXWIN_H__
	#error "PCH에 대해 이 파일을 포함하기 전에 'pch.h'를 포함합니다."
#endif

#include "resource.h"       // 주 기호입니다.


// CG24W04MFCApp:
// 이 클래스의 구현에 대해서는 G24W04MFC.cpp을(를) 참조하세요.
//

class CG24W04MFCApp : public CWinApp
{
public:
	CG24W04MFCApp() noexcept;


// 재정의입니다.
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// 구현입니다.
	// + application framework message : 메시지 처리 함수
	// + afx_msg는 써도 되고, 안 써도 되지만 메시지 처리하는 함수구나!하고 이해를 위해 표시함 (빈칸 낼수도)
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CG24W04MFCApp theApp;
