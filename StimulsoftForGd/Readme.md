В этом проекте полностью эмулируется работа ТОЛЬКО через mrt-файл чисто (без хардкода). 
А именно:
FakeController - endpoint который генерит данные (dataByPeriod2 - для 2019 или DataByPeriod - для 2020 года)

В файле payments-preset.mrt задаются 
 1. этот endpoint <PathData>http://localhost:5000/fake?sDate={sDate.ToString("yyyy-MM-dd")}</PathData>
 2. переменная sDate - параметр, который передается в endpoint
 3. стили и оформления

Через MyDesignerController можно донастроить переменные и стили
MyViewerController отображает данные 


Работает отчет с загруженными данными (пока settings = app1changed)
http://localhost:5000/myviewer?settingsId=app4&dataId=data2