using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab7
{
    public class Tests
    {
        //Расположение драйвера для работы с Гуглом
        private IWebDriver driver = new ChromeDriver(@"C:\Users\mbsdi\.nuget\packages\selenium.webdriver.chromedriver\112.0.5615.4900\");

        //Переходы по ссылкам для перехода к орме авторизации
        private readonly By _EntryButton = By.XPath("//a[text()='Вход']");// Ссылка на кнопку Войти

        private readonly By _PersonalCabinet = By.XPath("//font[text()=' Вход по личным паролям сотрудников и студентов']");// Ссылка на первый элемент в иерархии для дальнейшей регистрации

        private readonly By _LinkToRegistration = By.XPath("//a[text()='Новый пользователь или не можете войти?']"); //Ссылка на текст с линком на регистрацию

        private readonly By _LinkToRegPage = By.XPath("//a[text()='Зарегистрироваться']");// Ссылка на текст с линком на регистрационную форму

        private readonly By _ButtonToRegPage = By.XPath("//button[text()='Зарегистрироваться ']");//Кнопка для дальнейшей регистрации




        //Форма регистрации и инициализация полей для дальнейшей работы с ними

        private readonly By _Surname = By.XPath("//*[@id='r1:1:r1:0:it1::content']");//Поле для ввода фамилии

        private readonly By _Name = By.XPath("//*[@id='r1:1:r1:0:it2::content']");//Поле для ввода имени

        private readonly By _Fathername = By.XPath("//*[@id='r1:1:r1:0:it3::content']");//Поле для ввода отчества

        //private readonly By _SexCheckBox = By.XPath("[//*[@id='r1:1:r1:0:sor_sex:_0']");//Чек бокс мужского пола

        private readonly By _DateOfBirthday = By.XPath("//*[@id='r1:1:r1:0:id1::content']");//Поле для ввода даты рождения

        private readonly By _ChangeRegion = By.XPath("//select[@name='r1:1:r1:0:soc1']");//Поле для выбора региона

        private readonly By _RepublicOfTatarstan = By.XPath("//option[text()='16 - Республика Татарстан']");//Поле для выбора региона

        //Вторая часть формы регистрации
        private readonly By _Email = By.XPath("//input[@name='r1:1:r1:0:it4']");//Поле для майла

        private readonly By _Phone = By.XPath("//input[@name='r1:1:r1:0:it6']");//Поле для телеофна

        private readonly By _AgreeCheckbox = By.XPath("//input[@name='r1:1:sbc_agree']");//Чекбокс согласия с правилами

        private readonly By _ReadyButton = By.XPath("//button[text()='Готово']");//Кнопка "Готово" для дальнейшей регистрации


        //Метод преднастроек автотеста
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.kstu.ru/"); //Переходим на нужный нам сайт
            driver.Manage().Window.Maximize(); //Увеличиваем окно браузера на всь экран
        }

        //Метод настроек автотеста
        [Test]
        public void Test1()
        {
            //Кликаем на кнопку Вход
            var entry = driver.FindElement(_EntryButton);
            entry.Click();

            //Клик по кнопке Личный кабинет
            var personalCabinet = driver.FindElement(_PersonalCabinet);
            personalCabinet.Click();

            //Клик по ссылке внизу формы
            var linkToRegistration = driver.FindElement(_LinkToRegistration);
            linkToRegistration.Click();

            //Клик по тексту с ссылкой
            var linkToRegPage = driver.FindElement(_LinkToRegPage);
            linkToRegPage.Click();

            //Клик по кнопке регистрации и переход на форму
            var buttonToLinkPage = driver.FindElement(_ButtonToRegPage);
            buttonToLinkPage.Click();

            //Вводим фамилию
            Thread.Sleep(3000);
            var surname = driver.FindElement(_Surname);
            surname.SendKeys("Бабочкин"); //Сюда можно вставить любую фалмилию на выбор


            //Вводим имя
            Thread.Sleep(1000);
            var name = driver.FindElement(_Name);
            name.Click();
            name.SendKeys("Николай"); //Сюда вводим любое имя

            //Вводим отчество
            Thread.Sleep(1000);
            var fathername = driver.FindElement(_Fathername);
            fathername.SendKeys("Анатолиевич"); //Сюда вводим любое отчество

            //Выбор мужского пола в чекбоксе
            //Thread.Sleep(1000);
            //var sexCheckBox = driver.FindElement(_SexCheckBox);
            //sexCheckBox.Click();

            //Вводим дату рождения
            Thread.Sleep(1000);
            var dateOfBirthday = driver.FindElement(_DateOfBirthday);
            dateOfBirthday.SendKeys("13.12.1999"); //Сюда вводим дату рождения

            //Клик по кнопке форме выбора региона
            Thread.Sleep(1000);
            var changeRegion = driver.FindElement(_ChangeRegion);
            changeRegion.Click();

            //Клик по кнопке выбора республики Татарстан
            Thread.Sleep(1000);
            var republicOfTatarstan = driver.FindElement(_RepublicOfTatarstan);
            republicOfTatarstan.Click();


            //Далее пойдёт ввод эмайла и номера телефона.
            //Номер телефона необязательно вводить правильный, а вот эмайл - да
            //Сначала переходим на сайт десятиминутного майла и берем почту оттуда
            //Затем вставляем её в нужное поле, откуда будет браться строка для ввода майла в нужное поле

            //Вводим майл
            var email = driver.FindElement(_Email);
            email.SendKeys("tlg10815@zslsz.com"); //Сюда вводим майл из десятиминутного емайла

            //Вводим майл
            var phone = driver.FindElement(_Phone);
            phone.SendKeys("79874156734"); //Сюда вводим абсолютно любой нмоер телефона


            //Клик по чекбоксу с согласием с правилами
            var agreeCheckbox = driver.FindElement(_AgreeCheckbox);
            agreeCheckbox.Click();

            //Нажимаем кнопку "Готово и отправляем заполненную форму.
            //После чего нам на майл прилетит подтверждение нашей регистрации и переход в личный кабинет студента

            //Клик по кнопке готово
            var readyButton = driver.FindElement(_ReadyButton);
            readyButton.Click();

        }


        //Метод Постнастроек автотеста
        [TearDown]
        public void TearDown()
        {

        }
    }
}