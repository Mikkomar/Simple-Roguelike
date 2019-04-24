using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class EventLogger {
    
    private TextBox eventTextBox;

    public EventLogger(TextBox tb) {
        eventTextBox = tb;
    }

    public void logEvent(string eventMsg) {
        eventTextBox.Text += eventMsg;
    }

    public void Empty() {
        eventTextBox.Text = "";
    }
}
