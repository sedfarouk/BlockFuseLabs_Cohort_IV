# BlockFuse Labs Cohort IV — Web2 Submission

This repository contains the solutions for the BlockFuse Labs Cohort IV web2 assignments.
The goal of these exercises is to demonstrate core web development skills before being admitted to the Web3 program.

Repository structure

- Q1/
	- `Question_1.py` — Python function solving "longest substring without repeating characters" with tests and README.
	- `tests/` — pytest tests for Q1.
	- `requirements.txt` — test dependencies.

- Q2/
	- `TaskManagementSystemQ2/` — Minimal ASP.NET Core 8.0 application implementing a small Task Management API (create / list / complete / delete)
	- `TaskManagementSystemQ2/README.md` — run instructions, Swagger screenshots, and notes.

What you'll find here

- Clean, well-documented solutions for both questions.
- Unit tests for Q1 and example API snapshots for Q2 (Swagger screenshots included).

Quick start

1. Q1 (Python)

	 - Create and activate a virtual environment:

		 ```bash
		 python3 -m venv .venv
		 source .venv/bin/activate
		 pip install -r Q1/requirements.txt
		 pytest -q Q1/tests
		 ```

	 - Or run the example runner:

		 ```bash
		 python3 Q1/Question_1.py
		 ```

2. Q2 (ASP.NET Core minimal API)

	 - From the project folder run:

		 ```bash
		 cd Q2/TaskManagementSystemQ2
		 dotnet restore
		 dotnet run
		 ```

	 - By default the app uses a local SQLite file `taskmanagement.db`. To use Postgres, update `ConnectionStrings:DefaultConnection` in `Q2/TaskManagementSystemQ2/appsettings.json`.
	 - Swagger is enabled in Development and shows the available endpoints and example payloads. Screenshots are included in the Q2 README.

Design notes

- Q1: Uses an O(n) sliding-window algorithm with clear variable names, docstrings, and pytest tests covering normal and edge cases.
- Q2: Minimal API using EF Core. The `TaskItem` entity includes Title, Description, DueDate, IsCompleted, CreatedAt and CompletedAt. Endpoints return clean JSON and appropriate HTTP status codes.

Context

This project was prepared for the BlockFuse Labs Cohort IV intake. It is intended to show readiness for the Web3 curriculum by demonstrating solid Web2 fundamentals.
