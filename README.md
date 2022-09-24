# Title

CI | Core Infrastructure

# Description

Yeni özelliklerin geliştirilmesine ve teknoloji değişikliğine açık, SOLID prensiplerine uygun, esnek ve performanslı bir uygulama şeması oluşturmayı amaçlar.

# Layers

- Admin

Veri ve ileride eklenecek tüm özelliklerin kontrolünü amaçlar.

    ├── Api         : Application katmanına bağımlıdır, bu katmanın sağladığı operasyonları son kullanıcı ile buluşturmayı amaçlar. Bağımlı olduğu Application'ı consume eder.
    └── Application : Core katmanına bağımlıdır. Tüm altyapısal operasyonları "Core" katmanı üzerinden gerçekleştirir.

- UI

Herkese açık verileri sunmayı amaçlar.

    ├── Api         : Application katmanına bağımlıdır, bu katmanın sağladığı operasyonları son kullanıcı ile buluşturmayı amaçlar. Bağımlı olduğu Application'ı consume eder.
    └── Application : Core katmanına bağımlıdır. Tüm altyapısal operasyonları "Core" katmanı üzerinden gerçekleştirir.

- Core

Tüm katmanların kullanabileceği herkese açık bir altyapı sunmayı amaçlar. Domain, Infrastructure ve Data gibi alt katmanları bulunur.

    ├── Data            : Seçilen veri depolama teknolojisini soyutlamayı amaçlar. 
    ├── Domain          : Diğer katmanlardan bağımsız olarak, model, utilities gibi objeleri barındırır.
    └── Infrastructure   : Altyapısal tüm operasyonlar bu katmanda gerçekleştirilir.

# Folder Structure

    ├── src
    │   ├── Admin
    │   │   ├── Api
    │   │   │   └── Controllers
    │   │   └── Application
    │   │       ├── Dto
    │   │       ├── Mapper
    │   │       ├── Services
    │   │       └── Validations
    │   ├── Core
    │   │   ├── Data
    │   │   │   ├── Contexts
    │   │   │   └── Migrations
    │   │   ├── Domain
    │   │   │   ├── Dto
    │   │   │   ├── Entities
    │   │   │   ├── Enums
    │   │   │   ├── Exceptions
    │   │   │   ├── Helper
    │   │   │   ├── Middleware
    │   │   │   ├── Options
    │   │   │   └── ValueObjects
    │   │   └── Infrastructure
    │   │       ├── Log
    │   │       ├── Mail
    │   │       ├── Repositories
    │   │       ├── Sms
    │   │       ├── UnitOfWork
    │   │       └── Utility
    │   └── UI
    │       ├── Api
    │       │   └── Controllers
    │       └── Application
    │           ├── Dto
    │           ├── Mapper
    │           └── Services
    └── test
        ├── Integration.Test
        └── Unit.Test