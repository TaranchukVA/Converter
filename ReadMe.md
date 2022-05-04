# Программа выполняет  конвертацию валют по текущему курсу ЦБ России.

Курс валют запрашвиается с  "https://www.cbr-xml-daily.ru/daily_json.js"

Узнать ваюты и их коды: {aplicationUrl}/valutes

Пример запроса:
* Адрес:  {aplicationUrl}/convert
* Тело запроса:
```
{
    "oldCurency": "usd",
    "newCurency": "eur",
    "oldQuantity": 10000
}
```

Пример успешного ответа:
Код 200
```
{
    "oldCurency": "USD",
    "oldQuantity": 10000,
    "newCurency": "EUR",
    "newQuantity": 9525.85
}
```


Пример неуспешного ответа:
Код 400.
Новая валюта не передана

---
Владимир Таранчук
