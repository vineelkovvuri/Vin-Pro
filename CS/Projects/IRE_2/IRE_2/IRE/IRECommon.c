/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Implementation of common routines - Only Logging is currently implemented
 *
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "IRECommon.h"

// Logging is enabled only if LOG Marco is defined in the properties page of the project 
int Log(FILE *fp,const char *fmt, ...) 
{
//#ifdef LOG
   va_list ap;
   va_start(ap,fmt);
   vfprintf(fp,fmt,ap);
   va_end(ap);
//#endif
   return 0;
};


