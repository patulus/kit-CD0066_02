#include <afxwin.h>
//CWinApp app;  // �ݵ�� �ּ� ó���� ��!!!!!!

class CMyApp : public CWinApp {
public:
	virtual BOOL InitInstance();
};

class CMainWnd : public CFrameWnd {
public:
	CMainWnd();
};

BOOL CMyApp::InitInstance() {
	//::AfxMessageBox(L"�Ļ� Ŭ������ InitInstance() ������");

	m_pMainWnd = new CMainWnd;
	m_pMainWnd->ShowWindow(m_nCmdShow);
	m_pMainWnd->UpdateWindow();

	return TRUE;
}

CMainWnd::CMainWnd() {
	Create(NULL, L"GUI ���α׷���");
}

CMyApp app;