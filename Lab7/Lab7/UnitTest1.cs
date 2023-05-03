using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab7
{
    public class Tests
    {
        //������������ �������� ��� ������ � ������
        private IWebDriver driver = new ChromeDriver(@"C:\Users\mbsdi\.nuget\packages\selenium.webdriver.chromedriver\112.0.5615.4900\");

        //�������� �� ������� ��� �������� � ���� �����������
        private readonly By _EntryButton = By.XPath("//a[text()='����']");// ������ �� ������ �����

        private readonly By _PersonalCabinet = By.XPath("//font[text()=' ���� �� ������ ������� ����������� � ���������']");// ������ �� ������ ������� � �������� ��� ���������� �����������

        private readonly By _LinkToRegistration = By.XPath("//a[text()='����� ������������ ��� �� ������ �����?']"); //������ �� ����� � ������ �� �����������

        private readonly By _LinkToRegPage = By.XPath("//a[text()='������������������']");// ������ �� ����� � ������ �� ��������������� �����

        private readonly By _ButtonToRegPage = By.XPath("//button[text()='������������������ ']");//������ ��� ���������� �����������




        //����� ����������� � ������������� ����� ��� ���������� ������ � ����

        private readonly By _Surname = By.XPath("//*[@id='r1:1:r1:0:it1::content']");//���� ��� ����� �������

        private readonly By _Name = By.XPath("//*[@id='r1:1:r1:0:it2::content']");//���� ��� ����� �����

        private readonly By _Fathername = By.XPath("//*[@id='r1:1:r1:0:it3::content']");//���� ��� ����� ��������

        //private readonly By _SexCheckBox = By.XPath("[//*[@id='r1:1:r1:0:sor_sex:_0']");//��� ���� �������� ����

        private readonly By _DateOfBirthday = By.XPath("//*[@id='r1:1:r1:0:id1::content']");//���� ��� ����� ���� ��������

        private readonly By _ChangeRegion = By.XPath("//select[@name='r1:1:r1:0:soc1']");//���� ��� ������ �������

        private readonly By _RepublicOfTatarstan = By.XPath("//option[text()='16 - ���������� ���������']");//���� ��� ������ �������

        //������ ����� ����� �����������
        private readonly By _Email = By.XPath("//input[@name='r1:1:r1:0:it4']");//���� ��� �����

        private readonly By _Phone = By.XPath("//input[@name='r1:1:r1:0:it6']");//���� ��� ��������

        private readonly By _AgreeCheckbox = By.XPath("//input[@name='r1:1:sbc_agree']");//������� �������� � ���������

        private readonly By _ReadyButton = By.XPath("//button[text()='������']");//������ "������" ��� ���������� �����������


        //����� ������������ ���������
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.kstu.ru/"); //��������� �� ������ ��� ����
            driver.Manage().Window.Maximize(); //����������� ���� �������� �� ��� �����
        }

        //����� �������� ���������
        [Test]
        public void Test1()
        {
            //������� �� ������ ����
            var entry = driver.FindElement(_EntryButton);
            entry.Click();

            //���� �� ������ ������ �������
            var personalCabinet = driver.FindElement(_PersonalCabinet);
            personalCabinet.Click();

            //���� �� ������ ����� �����
            var linkToRegistration = driver.FindElement(_LinkToRegistration);
            linkToRegistration.Click();

            //���� �� ������ � �������
            var linkToRegPage = driver.FindElement(_LinkToRegPage);
            linkToRegPage.Click();

            //���� �� ������ ����������� � ������� �� �����
            var buttonToLinkPage = driver.FindElement(_ButtonToRegPage);
            buttonToLinkPage.Click();

            //������ �������
            Thread.Sleep(3000);
            var surname = driver.FindElement(_Surname);
            surname.SendKeys("��������"); //���� ����� �������� ����� �������� �� �����


            //������ ���
            Thread.Sleep(1000);
            var name = driver.FindElement(_Name);
            name.Click();
            name.SendKeys("�������"); //���� ������ ����� ���

            //������ ��������
            Thread.Sleep(1000);
            var fathername = driver.FindElement(_Fathername);
            fathername.SendKeys("�����������"); //���� ������ ����� ��������

            //����� �������� ���� � ��������
            //Thread.Sleep(1000);
            //var sexCheckBox = driver.FindElement(_SexCheckBox);
            //sexCheckBox.Click();

            //������ ���� ��������
            Thread.Sleep(1000);
            var dateOfBirthday = driver.FindElement(_DateOfBirthday);
            dateOfBirthday.SendKeys("13.12.1999"); //���� ������ ���� ��������

            //���� �� ������ ����� ������ �������
            Thread.Sleep(1000);
            var changeRegion = driver.FindElement(_ChangeRegion);
            changeRegion.Click();

            //���� �� ������ ������ ���������� ���������
            Thread.Sleep(1000);
            var republicOfTatarstan = driver.FindElement(_RepublicOfTatarstan);
            republicOfTatarstan.Click();


            //����� ����� ���� ������ � ������ ��������.
            //����� �������� ������������� ������� ����������, � ��� ����� - ��
            //������� ��������� �� ���� ��������������� ����� � ����� ����� ������
            //����� ��������� � � ������ ����, ������ ����� ������� ������ ��� ����� ����� � ������ ����

            //������ ����
            var email = driver.FindElement(_Email);
            email.SendKeys("tlg10815@zslsz.com"); //���� ������ ���� �� ��������������� ������

            //������ ����
            var phone = driver.FindElement(_Phone);
            phone.SendKeys("79874156734"); //���� ������ ��������� ����� ����� ��������


            //���� �� �������� � ��������� � ���������
            var agreeCheckbox = driver.FindElement(_AgreeCheckbox);
            agreeCheckbox.Click();

            //�������� ������ "������ � ���������� ����������� �����.
            //����� ���� ��� �� ���� �������� ������������� ����� ����������� � ������� � ������ ������� ��������

            //���� �� ������ ������
            var readyButton = driver.FindElement(_ReadyButton);
            readyButton.Click();

        }


        //����� ������������ ���������
        [TearDown]
        public void TearDown()
        {

        }
    }
}