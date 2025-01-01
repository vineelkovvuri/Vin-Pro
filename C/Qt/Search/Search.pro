#-------------------------------------------------
#
# Project created by QtCreator 2014-03-12T23:02:34
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = Search
TEMPLATE = app

RC_FILE = search.rc

SOURCES += main.cpp\
        mainwindow.cpp \
    searchthread.cpp

HEADERS  += mainwindow.h \
    searchthread.h

FORMS    += mainwindow.ui

OTHER_FILES += \
    search.rc
