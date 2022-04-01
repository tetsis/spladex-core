# Spladex Core
```
                 +---------------+
+----------+     |      +------+ |     +-----+
| Frontend |-----| API  | Core | |-----| RDB |
+----------+     |      + -----+ |     +-----+
                 +---------------+
                         |
              +---------------------+
              |            +------+ |
              | Scheduler  | Core | |
              |            + -----+ |
              +---------------------+
```

- Frontend
    - [Repo](https://github.com/tetsis/spladex-frontend)
    - React
    - Deployed in [vercel](https://vercel.com/)
        - [page](https://spladex.jp)
- API
    - [Repo](https://github.com/tetsis/spladex-api) (private)
    - ASP.NET
- Core (here)
    - [Repo](https://github.com/tetsis/spladex-core)
    - C#
- RDB
    - MySQL
- Scheduler
	- [Repo](https://github.com/tetsis/spladex-scheduler)
    - C#
    - Azure functions