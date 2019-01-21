using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace Maze.UI
{
    public class LogTextboxAppender : AppenderSkeleton
    {
        public static TextBox LoggingTextbox { get; set; }

        private static List<String> buffer = new List<string>();

        private System.Threading.Timer flushTimer = new System.Threading.Timer(Flush);

        // todo: сделано в первом приближении, нужно пересмотреть, потокобезопасности нет

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (LoggingTextbox != null)
            {
                String mes = RenderLoggingEvent(loggingEvent) + Environment.NewLine;
                buffer.Add(mes);
                flushTimer.Change(100, System.Threading.Timeout.Infinite);
            }
        }

        private static void Flush(object state)
        {
            if (LoggingTextbox != null)
            {
                String all = String.Join("", buffer.ToArray());
                LoggingTextbox.Invoke((Action)(() =>
                {
                    LoggingTextbox.AppendText(all);
                }));
                buffer.Clear();
            }
        }
    }
}
