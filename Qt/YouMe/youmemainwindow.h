#ifndef YOUMEMAINWINDOW_H
#define YOUMEMAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class YouMeMainWindow;
}

class YouMeMainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit YouMeMainWindow(QWidget *parent = 0);
    ~YouMeMainWindow();
    
private:
    Ui::YouMeMainWindow *ui;
};

#endif // YOUMEMAINWINDOW_H
