#pragma once


#define DEFINE_AND_CALL_FUNC(func) extern int func();\
								   func();

#define DEFINE_FUNC(func) extern int func();


