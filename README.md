# MVC_Simple_Calculator

Данное веб-приложение является простым калькулятором, с использованием базы данных SQL Server 2012.

# Руководство по эксплуатации

При запуске веб-приложения, пользователю представляется форма ввода значений для расчета
![Image alt](https://github.com/alexmokshin/MVC_Simple_Calculator/raw/master/MVC_Simple_Calculator/Images/start_form.PNG)

В качестве операнда необходимо использовать следующие символы: +, -, /, *.
После ввода значений, необходимо нажать кнопку "Рассчитать". В поле "Результат" появится результат произведенных вычислений.
![Image alt](https://github.com/alexmokshin/MVC_Simple_Calculator/raw/master/MVC_Simple_Calculator/Images/calc_result.PNG)

При нажатии кнопки "Показать историю расчетов", будет совершен запрос в базу данных, и по IP пользователя вернутся введенные значения.
![Image alt](https://github.com/alexmokshin/MVC_Simple_Calculator/raw/master/MVC_Simple_Calculator/Images/calc_history.PNG)

Если рядом со строкой нажать кнопку Retry - можно повторить ранее использованный расчет.
