#include <QMessageBox>
#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "searchthread.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pbSearch_clicked()
{
//    QMessageBox msgBox;
//    msgBox.setText(tr("File Name ") + ui->leFileName->text());
//    if (msgBox.exec() == QMessageBox::Accepted);

    SearchThread *st = new SearchThread(this, ui->leFileName->text());
    QObject::connect(st, SIGNAL(postStatusText(const QString&)),
            this, SLOT(statusTextUpdate(const QString&)));
    QObject::connect(st, SIGNAL(postResults(const QString&)),
            this, SLOT(resultsUpdate(const QString&)));
    QObject::connect(this, SIGNAL(postStopSearch(const bool&)),
            st, SLOT(handleStopSearch(const bool&)));

    st->start();
}

void MainWindow::statusTextUpdate(const QString& searchPath)
{
    ui->lStatus->setText(searchPath);
//    QMessageBox msgBox;
//    msgBox.setText(tr("File Name ") + searchPath);
//    if (msgBox.exec() == QMessageBox::Accepted);
}

void MainWindow::on_pbStop_clicked()
{
    emit postStopSearch(true);
}

void MainWindow::resultsUpdate(const QString& filePath)
{
    ui->lwResults->addItem(filePath);
}
