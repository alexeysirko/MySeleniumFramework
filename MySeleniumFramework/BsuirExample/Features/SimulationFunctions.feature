﻿Feature: SimulationFunctions
Как студент БГУИР
Я хочу пользоваться всеми элементами веб-сайта
Чтобы получить доступ к необходимой информации университета

Background: 
Given Открыта страница БГУИР
Then Отображается галерея основной страницы БГУИР

@Click
Scenario: Функция Кликнуть на элемент
Given Кликами пролистаны слайды на главной странице
When Нажатие на кнопку "Наука" из меню
Then Отображается заголовок страницы Наука

@GetText
Scenario: Функция Получить текст элемента
Given Получен текст логотипа 
Then Текст логотипа соотвествует "Белорусский государственный университет  информатики и радиоэлектроники"
When Изменить язык страницы на английский
And Получить текст логотипа ещё раз
Then Текст логотипа соотвествует "BELARUSIAN STATE UNIVERSITY OF INFORMATICS AND RADIOELECTRONICS"

@Scroll
Scenario: Функция Прокрутка до элемента
Given Прокрутить страницу БГУИР до футера
Then Кнопка Связаться с нами отображается на экране

When Прокрутить страницу БГУИР до хедера
Then Основной логотип БГУИР отображается на экране

@HoverMouse
Scenario: Функция наведения мыши на элемент
When Наведение мыши на соответсвущую опцию из меню
Then В выпадающем меню отображается соответсвующая опция
| Название кнопки              | Опция меню                                                                 |
| Университет                  | Общая информация, Совет университета, Фотогалерея, Документы               |
| Образование                  | Специальности, Магистратура, Библиотека, Оплата  обучения                  |
| Наука                        | Лаборатории и центры, Научные школы, Научные мероприятия                   |
| Молодёжная политика          | События года, Структура управления, Спорт в университете, Культурная жизнь |
| Международное сотрудничество | Иностранным гражданам, Почётные доктора БГУИР, Межвузовское сотрудничество |
| Контакты                     | Обратная связь, Приемная комиссия, Схема корпусов, Телефонный справочник   |

@Delete
Scenario: Функция удаления элемента
When Удаление среднего хедера страницы
Then Главный логотип и строка поиска ичесзли со страницы

@TextInput
Scenario: Функция ввода текста и получения CSS значения
Given Ввожу текст "Расписание" в поисковую строку
When Нажимаю кнопку поиска
Then Страница Поиска открыта
And Введенный текст отображается в новой строке поиска

@FindListOfElements
Scenario: Функция работы с большим колчеством элементов
When Я перехожу на страницу Достижений
Then На странице достижений отображается множество ссылок

@Registration
Scenario: Вход в почту БГУИР
Given Нажимаю на иконку почты
When Я ввожу логин "01090049" и пароль "MyPassword123"
Then Данные отображаются на странице