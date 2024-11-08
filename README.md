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

Управление структурой вуза; Управление пользователями системы; Добавление пользователя системы; Управление приёмной кампанией; Управление использования бд;
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationStruct.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationUsers.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationAddUser.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationAdmissionsCampaign.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdministrationBD.png" Height="300" Width="500"/>
</div>

2. Модуль "Приёмная кампания".

Главная страница модуля с карточкой абитуриента; Добавление абитуриента перчая часть; Добавление абитуриента вторая часть;
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmisionCampaign.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmissionCampaignAddApplicant1.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/AdmissionCampaignAddApplicant2.png" Height="300" Width="500"/>
</div>

3. Модуль "Деканат".

Доступ к факультету по паролю; Добавление группы; Добавление студента;
<div>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAccess.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAndAddGroup.png" Height="300" Width="500"/>
  <img src="https://github.com/EddoCoding/EducationERP/blob/main/DeanRoomAcceptStudent.png" Height="300" Width="500"/>
</div>

Запланировано, написание модулей:
1. Ректор.
2. Преподаватель.
3. Воинский учет.
4. Хозяйственная часть.
5. Учебный отдел.
6. Библиотека.
7. Общий функционал (Электронный документооборот, мессенджер, система уведомлений, временное храненеи файлов).
