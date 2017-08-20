#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

public slots:
    void statusTextUpdate(const QString& searchPath);
    void resultsUpdate(const QString& filePath);

private slots:
    void on_pbSearch_clicked();
    void on_pbStop_clicked();

signals:
    void postStopSearch(const bool stop);
private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
