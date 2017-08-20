#-------------------------------------------------
#
# Project created by QtCreator 2014-04-01T19:41:53
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = YouMe
TEMPLATE = app


SOURCES += main.cpp\
        youmemainwindow.cpp \
    board.cpp \
    cell.cpp \
    point.cpp

HEADERS  += youmemainwindow.h \
    board.h \
    cell.h \
    point.h

FORMS    += youmemainwindow.ui
