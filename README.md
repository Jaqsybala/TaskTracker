# Task Tracker App

## О проекте

В проекте была использована архитектура - [Traditional "N-Layer" architecture applications](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#traditional-n-layer-architecture-applications)

Использован .Net6.0 SDK
Для база данных использована - PostgresSQL 14

## Структура проекта 

- TaskTracker.DataAccess - хранится сущности проекта и DbContext
- TaskTracker.Logic - здесь вся бизнес логика проекта, через Managers
- TaskTracker.API - стартап проект (нужно установить как проект для старта), Web API проекта

Название базы - Tasker


## Как запустить проект
> P.S. делать миграцию не нужно, запускается при каждом запуске программы

1. Клониреум проект с [Гита](https://github.com/Jaqsybala/TaskTracker.git)
2. Открываем проект в VS
3. TaskTracker.API - устанавливаем как стартап проект
4. И запускаем :)


## Тестирование

> Только учусь ;)
