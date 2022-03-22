# Splatoon2 Video Index Core
## Architecture
```
                 +---------------+
+----------+     |      +------+ |     +-----+
| Frontend |-----| API  | Core | |-----| RDB |
+----------+     |      + -----+ |     +-----+
                 +---------------+
                         |
                   +-----------+
                   | Scheduler |
                   +-----------+
```

- Frontend
    - [Repo](https://github.com/tetsis/splatoon2-video-index-frontend)
    - React
- API
    - [Repo](https://github.com/tetsis/splatoon2-video-index-api)
    - ASP.NET
- Core (here)
    - [Repo](https://github.com/tetsis/splatoon2-video-index-core)
    - C#
- RDB
    - MySQL
- Scheduler
    - [Repo]()
    - C#
    - Azure functions