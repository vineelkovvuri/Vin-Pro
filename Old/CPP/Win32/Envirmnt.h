/* Envirmnt.h -- define UNICODE and _MT here. */
/* It is best and easiest to define UNICODE within the project. */
/* Use Project...Settings...C/C++. Then, in the "Project Options" */
/* window on the bottom, add /D "UNICODE". */
/* Do the same for _MT, and _STATIC_LIB. */

//#define UNICODE
#undef UNICODE
#ifdef UNICODE
#define _UNICODE
#endif

#ifndef UNICODE
#undef _UNICODE
#endif


//#define _STATICLIB
          /* Define _STATICLIB if you are either building a */
          /* static library or linking with one. */
#define LANG_DFLT LANG_ENGLISH
#define SUBLANG_DFLT SUBLANG_ENGLISH_US


