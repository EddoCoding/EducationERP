EducationERP - Программа для автоматизирования и автоматизации процессов в учебных заведениях.

С предыдущим проектом сделаного для диплома можете ознакомиться по ссылке. (https://github.com/EddoCoding/ERPeducation).

Для текущего проекта используется собственная IoC библиотека реализующая DI контейнер, сервис представления и команды;
Для хранения данных используется PostgreSQL с ORM EF - миграционный подход.

Пока сделано:
1. Модуль "Администрирование" (Взаимодействие с базой данных PostgreSQL, управление пользователями ERP-системы).
2. Вход по ролям с открытием нужных модулей и подпредставлений для деканата представляющий различныые факультеты.
3. Модуль "Приёмная кампания" (Кроме электронного документооборота).

В РАБОТЕ:
1. Модуль "Деканат".

Скриншоты того, что пока готово.
1. Модуль "Администрирование".

Управление структурой вуза.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationStruct.png" Height="500" Width="700"/>
</div>

Управление пользователями системы.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationUsers.png" Height="500" Width="700"/>
</div>

Добавление пользователя системы.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationAddUser.png" Height="500" Width="700"/>
</div>

Управление приёмной кампанией.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationAdmissionsCampaign.png" Height="500" Width="700"/>
</div>

Управление использования бд.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationBD.png" Height="500" Width="700"/>
</div>

2. Модуль "Приёмная кампания".

Главная страница модуля "Приёмная кампания" с карточкой абитуриента.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmisionCampaign.png" Height="500" Width="700"/>
</div>

Добавление абитуриента перчая часть.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmissionCampaignAddApplicant1.png" Height="500" Width="700"/>
</div>

Добавление абитуриента вторая часть.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmissionCampaignAddApplicant2.png" Height="500" Width="700"/>
</div>

3. Модуль "Деканат".

Доступ к факультету по паролю.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAccess.png" Height="500" Width="700"/>
</div>

Деканат. Добавление группы.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAndAddGroup.png" Height="500" Width="700"/>
</div>

Деканат. Добавление студента.
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAcceptStudent.png" Height="500" Width="700"/>
</div>

Запланировано, написание модулей:
1. Ректор.
2. Преподаватель.
3. Воинский учет.
4. Хозяйственная часть.
5. Учебный отдел.
6. Библиотека.
7. Общий функционал (Электронный документооборот, мессенджер, система уведомлений, временное храненеи файлов).
