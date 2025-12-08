import pytest
import importlib
import sys
from typing import Callable

try:
    mod = importlib.import_module("Q1.Question_1")
except ModuleNotFoundError:
    # If running tests with working directory set to Q1/, import directly.
    if "" not in sys.path:
        sys.path.insert(0, "")
    mod = importlib.import_module("Question_1")

length_of_longest_substring: Callable[[str], int] = mod.length_of_longest_substring


@pytest.mark.parametrize(
    "s, expected",
    [
        ("abcabcbb", 3),
        ("bbbbb", 1),
        ("pwwkew", 3),
        ("", 0),
        (" ", 1),
        ("au", 2),
        ("dvdf", 3)
    ],
)
def test_length_of_longest_substring(s, expected):
    assert length_of_longest_substring(s) == expected
