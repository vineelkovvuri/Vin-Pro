; ModuleID = 'classdecl.cc'
target datalayout = "e-p:32:32:32-i1:8:8-i8:8:8-i16:16:16-i32:32:32-i64:64:64-f32:32:32-f64:64:64-f80:128:128-v64:64:64-v128:128:128-a0:0:64-f80:32:32-n8:16:32"
target triple = "i386-pc-mingw32"

%0 = type { i32, void ()* }
%class.Book = type { i32, i32 }
%"class.std::basic_ostream" = type { i32 (...)**, [136 x i8] }
%"class.std::basic_streambuf" = type { i32 (...)**, i8*, i8*, i8*, i8*, i8*, i8*, %"class.std::locale" }
%"class.std::ctype" = type { [8 x i8], i32*, i8, i32*, i32*, i16*, i8, [256 x i8], [256 x i8], i8 }
%"class.std::ios_base" = type { i32 (...)**, i32, i32, i32, i32, i32, %"struct.std::ios_base::_Callback_list"*, %"struct.std::ios_base::_Words", [8 x %"struct.std::ios_base::_Words"], i32, %"struct.std::ios_base::_Words"*, %"class.std::locale" }
%"class.std::ios_base::Init" = type { i8 }
%"class.std::locale" = type { %"class.std::locale::_Impl"* }
%"class.std::locale::_Impl" = type { i32, %"class.std::locale::facet"**, i32, %"class.std::locale::facet"**, i8** }
%"class.std::locale::facet" = type { i32 (...)**, i32 }
%"class.std::num_get" = type { [8 x i8] }
%"class.std::num_put" = type { [8 x i8] }
%"enum.std::_Ios_Fmtflags" = type i32
%"enum.std::_Ios_Iostate" = type i32
%"enum.std::ios_base::event" = type i32
%"struct.std::ios_base::_Callback_list" = type { %"struct.std::ios_base::_Callback_list"*, void (i32, %"class.std::ios_base"*, i32)*, i32, i32 }
%"struct.std::ios_base::_Words" = type { i8*, i32 }

@_ZStL8__ioinit = internal global %"class.std::ios_base::Init" zeroinitializer, align 1
@_ZSt4cout = external global %"class.std::basic_ostream"
@.str = private unnamed_addr constant [2 x i8] c" \00"
@llvm.global_ctors = appending global [1 x %0] [%0 { i32 65535, void ()* @_GLOBAL__I_a }]
@llvm.global_dtors = appending global [1 x %0] [%0 { i32 65535, void ()* @_GLOBAL__D_a }]

define internal void @__cxx_global_var_init() {
  call void @_ZNSt8ios_base4InitC1Ev(%"class.std::ios_base::Init"* @_ZStL8__ioinit)
  ret void
}

declare void @_ZNSt8ios_base4InitC1Ev(%"class.std::ios_base::Init"*)

declare void @_ZNSt8ios_base4InitD1Ev(%"class.std::ios_base::Init"*)

define i32 @main() {
  %1 = alloca i32, align 4
  %b1 = alloca %class.Book, align 4
  store i32 0, i32* %1
  %2 = getelementptr inbounds %class.Book* %b1, i32 0, i32 0
  %3 = load i32* %2, align 4
  %4 = call %"class.std::basic_ostream"* @_ZNSolsEi(%"class.std::basic_ostream"* @_ZSt4cout, i32 %3)
  %5 = call %"class.std::basic_ostream"* @_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc(%"class.std::basic_ostream"* %4, i8* getelementptr inbounds ([2 x i8]* @.str, i32 0, i32 0))
  %6 = getelementptr inbounds %class.Book* %b1, i32 0, i32 1
  %7 = load i32* %6, align 4
  %8 = call %"class.std::basic_ostream"* @_ZNSolsEi(%"class.std::basic_ostream"* %5, i32 %7)
  %9 = load i32* %1
  ret i32 %9
}

declare %"class.std::basic_ostream"* @_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc(%"class.std::basic_ostream"*, i8*)

declare %"class.std::basic_ostream"* @_ZNSolsEi(%"class.std::basic_ostream"*, i32)

define internal void @_GLOBAL__I_a() {
  call void @__cxx_global_var_init()
  ret void
}

define internal void @_GLOBAL__D_a() {
  call void @_ZNSt8ios_base4InitD1Ev(%"class.std::ios_base::Init"* @_ZStL8__ioinit)
  ret void
}
