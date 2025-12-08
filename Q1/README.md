# Question 1 — Longest Substring Without Repeating Characters

This repository contains the solution for the "longest substring without repeating characters" problem asked in the BlockFuse Labs Cohort IV Test.

Files
- `Question_1.py`: Implementation with docstring and example CLI runner.
- `tests/test_question1.py`: Pytest unit tests covering common and edge cases.
- `requirements.txt`: Python test dependency (pytest).

How to run locally

1. Create and activate a virtual environment (recommended):

```bash
python3 -m venv .venv
source .venv/bin/activate
```

2. Install test dependencies:

```bash
pip install -r Q1/requirements.txt
```

3. Run tests:

```bash
pytest -q Q1/tests
```

Or, run the module directly to see example outputs:

```bash
python3 Q1/Question_1.py
```

Notes on the solution

- The implementation uses a sliding window with a dictionary to track last seen indices.
- Time complexity: O(n). Space complexity: O(min(n, charset_size)).
