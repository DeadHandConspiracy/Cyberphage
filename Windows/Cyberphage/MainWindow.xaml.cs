using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32; // For OpenFileDialog/SaveFileDialog
using System.Xml.Serialization; // For XML serialization


namespace Cyberphage
{/*
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Author: James Almond                                                   %
% Original Project Creation Date: 3/9/2021                               %
%                                                                        %
% Last Update Date: 3/9/2021                                             %
%                                                                        %
% Function: Run Genetic Algorithm on stript Program Robocom              %
%                                                                        %
% Description:                                                           %
%      The genetic algorithm (GA) is an advanced optimization            %
%      technique inspired by the principles of natural selection         %
%      and biological evolution. At its core, the genetic                %
%      algorithm mimics the process through which living                 %
%      organisms evolve and adapt over generations to their              %
%      environments, leading to the survival of the fittest.             %
%                                                                        %
% How Genetic Algorithms Work:                                           %
%      Initialization: The process begins with a randomly generated      %
%      population of potential solutions, often encoded as strings       %
%      (chromosomes). Each solution in the population is a candidate     % 
%      for solving the optimization problem.                             %
%                                                                        %
%      Evaluation: Each candidate solution is evaluated using a fitness  %
%      function, which measures how well it solves the problem at hand.  %
%      The fitness function assigns a score to each solution based on    %
%      its performance.                                                  %
%                                                                        %
%      Selection: The most promising solutions are selected to form a    %
%      new generation. This selection process is biased towards          %
%      solutions with higher fitness scores, ensuring that               %
%      better-performing solutions have a higher chance of being passed  %
%      on to the next generation.                                        %
%                                                                        %   
%      Crossover (Recombination): Selected solutions (parents) are       %
%      paired and combined to produce offspring. This process involves   %
%      exchanging segments of their strings to create new solutions.     %
%      Crossover encourages the combination of high-performance traits   %
%      from different parents, potentially leading to even better        %
%      solutions.                                                        %
%                                                                        %   
%      Mutation: To maintain genetic diversity and explore new           %
%      solutions, random modifications are introduced to some solutions. % 
%      Mutation alters a small part of a solution's string, preventing   %
%      the algorithm from converging too quickly on suboptimal           %
%      solutions.                                                        %
%                                                                        %   
%      Iteration: The new generation of solutions undergoes the same     %
%      evaluation, selection, crossover, and mutation processes. This    %
%      iterative cycle continues until a stopping criterion is met, such % 
%      as reaching a maximum number of generations or achieving a        %
%      satisfactory fitness level.                                       %
%                                                                        %
%                                                                        %
% Application in Autonomous Programming:                                 %
%      This genetic algorithm framework can be harnessed to develop      %
%      autonomous programs or "robots" that solve complex problems       %
%      without human intervention. The objective is to evolve highly     %
%      efficient and effective schemata—short, low-order,                %
%      high-performance building blocks that can be combined to form     %
%      superior solutions. These building blocks simplify the problem    %
%      by breaking it down into manageable components that can be        %
%      optimized individually and collectively.                          %
%                                                                        %
% The genetic algorithm operates as follows:                             %
%      Representation: The program's functionality is encoded as a       %
%      string of schemata. Each schema represents a specific behavior    %
%      or subroutine.                                                    %
%                                                                        %
%      Fitness Function: The fitness function evaluates the program's    %
%      performance, measuring criteria such as speed, accuracy, and      %
%      resource efficiency. Programs that perform better in these        %
%      aspects receive higher fitness scores.                            %
%                                                                        %
%      Evolution: Over successive generations, the algorithm samples,    %
%      recombines, and resamples these schemata to create new programs   %
%      with potentially higher fitness. The recombination of             %
%      high-performance schemata increases the likelihood of producing   %
%      robust and efficient programs.                                    %
%                                                                        %
%      Optimization: This evolutionary process reduces the complexity of %
%      developing unique code that can outperform human-built solutions. %
%      By iteratively refining the schemata and their combinations, the  %
%      genetic algorithm discovers innovative approaches and optimizes   %
%      the program's performance.                                        %
%                                                                        %
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
*/

    // Serializable data model
    public class ButtonData
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public required string Content { get; set; }
        public required string Color { get; set; } // Store color as string (e.g., "LightBlue")
    }

    public partial class MainWindow : Window
    {

        // Add these methods inside your MainWindow class

        // 1. Save Canvas elements to XML
        private void SaveCanvas_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*",
                DefaultExt = ".xml"
            };

            if (dlg.ShowDialog() == true)
            {
                List<ButtonData> buttonsData = [];

                // Extract data from each button on the Canvas
                foreach (UIElement element in MyCanvas.Children)
                {
                    if (element is Button btn)
                    {
                        buttonsData.Add(new ButtonData
                        {
                            Left = Canvas.GetLeft(btn),
                            Top = Canvas.GetTop(btn),
                            Content = btn.Content.ToString(),
                            // Simplify color saving (store the name if it's a standard brush)
                            Color = btn.Background is SolidColorBrush sb ? sb.Color.ToString() : "LightBlue"
                        });
                    }
                }

                // Serialize to XML
                XmlSerializer serializer = new(typeof(List<ButtonData>));
                using FileStream stream = new(dlg.FileName, FileMode.Create);
                serializer.Serialize(stream, buttonsData);
            }
        }

        // 2. Load Canvas elements from XML
        private void LoadCanvas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new()
            {
                Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                // Clear existing buttons
                MyCanvas.Children.Clear();

                List<ButtonData> buttonsData;
                XmlSerializer serializer = new(typeof(List<ButtonData>));

                using (FileStream stream = new(dlg.FileName, FileMode.Open))
                {
                    buttonsData = (List<ButtonData>)serializer.Deserialize(stream);
                }

                // Recreate buttons
                foreach (var data in buttonsData)
                {
                    Button newBtn = new()
                    {
                        Content = data.Content,
                        Width = 100,
                        Height = 50,
                        Cursor = Cursors.Hand
                    };

                    // Restore color
                    try
                    {
                        newBtn.Background = (Brush)new BrushConverter().ConvertFromString(data.Color);
                    }
                    catch
                    {
                        newBtn.Background = Brushes.LightBlue;
                    }

                    // Re-attach drag events
                    newBtn.PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
                    newBtn.PreviewMouseMove += Button_PreviewMouseMove;
                    newBtn.PreviewMouseLeftButtonUp += Button_PreviewMouseLeftButtonUp;

                    // Set position
                    Canvas.SetLeft(newBtn, data.Left);
                    Canvas.SetTop(newBtn, data.Top);

                    MyCanvas.Children.Add(newBtn);
                }
            }
        }


        // Helper class to store drag state per button
        private class DragState
        {
            public bool IsDragging { get; set; }
            public Point InitialClick { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // 1. Add a new button dynamically
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Button newBtn = new()
            {
                Content = "Drag Me",
                Width = 100,
                Height = 50,
                Background = Brushes.LightBlue,
                Cursor = Cursors.Hand
            };

            // Attach events to this specific button
            newBtn.PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
            newBtn.PreviewMouseMove += Button_PreviewMouseMove;
            newBtn.PreviewMouseLeftButtonUp += Button_PreviewMouseLeftButtonUp;

            // Add to Canvas
            MyCanvas.Children.Add(newBtn);

            // Set initial random-ish position
            int offset = MyCanvas.Children.Count * 20;
            Canvas.SetLeft(newBtn, 50 + offset);
            Canvas.SetTop(newBtn, 50 + offset);
        }

        // 2. Mouse Down: Initialize drag state
        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Button button) return;

            var state = new DragState
            {
                IsDragging = true,
                InitialClick = e.GetPosition(button)
            };

            button.Tag = state;
            button.CaptureMouse();

            // Optional: Visual feedback on click
            button.Background = Brushes.LightGreen;
        }

        // 3. Mouse Move: Handle dragging and collision
        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is not Button button) return;

            // Retrieve state specific to this button
            if (button.Tag is not DragState state || !state.IsDragging) return;

            Point currentMousePos = e.GetPosition(MyCanvas);
            double proposedLeft = currentMousePos.X - state.InitialClick.X;
            double proposedTop = currentMousePos.Y - state.InitialClick.Y;

            // Define the proposed rectangle for the moving button
            Rect proposedBounds = new(proposedLeft, proposedTop, button.ActualWidth, button.ActualHeight);
            bool hasCollision = false;

            // Check collision against EVERY other button on the canvas
            foreach (UIElement element in MyCanvas.Children)
            {
                if (element is Button otherButton && otherButton != button)
                {
                    Rect otherBounds = GetButtonBounds(otherButton, MyCanvas);
                    if (proposedBounds.IntersectsWith(otherBounds))
                    {
                        hasCollision = true;
                        // Optional: Visual feedback on the button being hit
                        otherButton.Background = Brushes.LightCoral;
                        break;
                    }
                    else
                    {
                        // Reset color if not colliding
                        if (otherButton.Background == Brushes.LightCoral)
                            otherButton.Background = Brushes.LightBlue;
                    }
                }
            }

            if (!hasCollision)
            {
                Canvas.SetLeft(button, proposedLeft);
                Canvas.SetTop(button, proposedTop);
            }
        }

        // 4. Mouse Up: End drag
        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Button button) return;

            if (button.Tag is DragState state)
            {
                state.IsDragging = false;
            }
            button.ReleaseMouseCapture();

            // Reset visual feedback
            button.Background = Brushes.LightBlue;

            // Reset any other buttons that might have turned red during drag
            foreach (UIElement element in MyCanvas.Children)
            {
                if (element is Button otherButton && otherButton != button)
                {
                    if (otherButton.Background == Brushes.LightCoral)
                        otherButton.Background = Brushes.LightBlue;
                }
            }
        }

        // Helper: Get the bounding rectangle of a button relative to the Canvas
        private static Rect GetButtonBounds(Button button, Canvas canvas)
        {
            // Ensure the button has been rendered to have valid ActualWidth/Height
            if (button.ActualWidth == 0 || button.ActualHeight == 0)
            {
                // Fallback if not yet rendered (use Width/Height)
                double left = Canvas.GetLeft(button);
                double top = Canvas.GetTop(button);
                return new Rect(left, top, button.Width, button.Height);
            }

            GeneralTransform transform = button.TransformToVisual(canvas);
            return transform.TransformBounds(new Rect(0, 0, button.ActualWidth, button.ActualHeight));
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



    }



}