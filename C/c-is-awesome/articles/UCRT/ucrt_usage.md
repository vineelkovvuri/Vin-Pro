## Learnings from each UCRT API

- assert.h
  - assert - This API do not take additional string argument, It only takes conditional
  - static_assert - Strange: This API can be used without using any header.
- ctype.h
  - ispunct - checks if a character is a punctuation character
- errno.h
  - errno - it is a **preprocessor macro** which expands to an int. In MSVC it expands
    to `(*_errno())` and in gcc it expands to `(*__errno_location())`
- \_\_WIN32__ - this macro is defined by MingW environment