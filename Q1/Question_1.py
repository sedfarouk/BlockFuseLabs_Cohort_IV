"""Utilities for Question 1: longest substring without repeating characters.

This module provides a clean implementation of the
length-of-longest-substring problem (Question 1). The function runs in
O(n) time and uses O(min(n, |charset|)) space.
"""

from typing import Dict

def length_of_longest_substring(s: str) -> int:
    """Return the length of the longest substring without repeating characters.

    Args:
        s: Input string.

    Returns:
        The maximum length of a substring that contains no repeated characters.

    Time complexity: O(n) where n = len(s).
    Space complexity: O(min(n, charset_size)).
    """
    left = 0
    max_length = 0
    last_seen: Dict[str, int] = {}

    for right, ch in enumerate(s):
        # If we've seen ch within the current window, move left past it.
        if ch in last_seen and last_seen[ch] >= left:
            left = last_seen[ch] + 1
        last_seen[ch] = right
        max_length = max(max_length, right - left + 1)

    return max_length


if __name__ == "__main__":
    examples = ["abcabcbb", "bbbbb", "pwwkew", "", " "]
    for ex in examples:
        print(f"{ex!r} -> {length_of_longest_substring(ex)}")
