
// G24W06MFCLottoDlg.cpp: 구현 파일
//

#include "pch.h"
#include "framework.h"
#include "G24W06MFCLotto.h"
#include "G24W06MFCLottoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 응용 프로그램 정보에 사용되는 CAboutDlg 대화 상자입니다.

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

// 구현입니다.
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CG24W06MFCLottoDlg 대화 상자



CG24W06MFCLottoDlg::CG24W06MFCLottoDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_G24W06MFCLOTTO_DIALOG, pParent)
	, Num1(_T(""))
	, Num2(_T(""))
	, Num3(_T(""))
	, Num4(_T(""))
	, Num5(_T(""))
	, Num6(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	// 매번 바뀌므로 테스트 시에는 시드를 고정하자.
	// #ifdef __DEBUG__ ~ #ELSE ~
	srand((unsigned)time(NULL));
}

void CG24W06MFCLottoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_NUM1, Num1);
	DDX_Text(pDX, IDC_NUM2, Num2);
	DDX_Text(pDX, IDC_NUM3, Num3);
	DDX_Text(pDX, IDC_NUM4, Num4);
	DDX_Text(pDX, IDC_NUM5, Num5);
	DDX_Text(pDX, IDC_NUM6, Num6);
}

BEGIN_MESSAGE_MAP(CG24W06MFCLottoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_GENERATE, &CG24W06MFCLottoDlg::OnBtnGenerateClicked)
END_MESSAGE_MAP()


// CG24W06MFCLottoDlg 메시지 처리기

BOOL CG24W06MFCLottoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 시스템 메뉴에 "정보..." 메뉴 항목을 추가합니다.

	// IDM_ABOUTBOX는 시스템 명령 범위에 있어야 합니다.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != nullptr)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 이 대화 상자의 아이콘을 설정합니다.  응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	// TODO: 여기에 추가 초기화 작업을 추가합니다.

	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

void CG24W06MFCLottoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다.  문서/뷰 모델을 사용하는 MFC 애플리케이션의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CG24W06MFCLottoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 그리기를 위한 디바이스 컨텍스트입니다.

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 클라이언트 사각형에서 아이콘을 가운데에 맞춥니다.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 아이콘을 그립니다.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// 사용자가 최소화된 창을 끄는 동안에 커서가 표시되도록 시스템에서
//  이 함수를 호출합니다.
HCURSOR CG24W06MFCLottoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CG24W06MFCLottoDlg::OnBtnGenerateClicked()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	//AfxMessageBox(L"버튼 클릭");

	// CString의 format 멤버 함수 printf와 동일한 사용법
	CString num;
	num.Format(L"%d", rand() % 45 + 1); // 1 ~ 45
	Num1 = num; // == Num1.Format();

	CArray<int, int> nums;
	int randNum;
	int i, j;
	for (i = 0; i < 6; i++)
	{
		randNum = rand() % 45 + 1;
		for (j = 0; j < nums.GetCount(); j++)
		{
			if (randNum == nums[j]) break;
		}
		if (j == nums.GetCount()) nums.Add(randNum);
	}


	UpdateData(FALSE); // TRUE: 화면 내용을 변수로 가져옴, FALSE: 변수 내용을 화면 내용으로 가져옴, 기본: TRUE
}
