﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

#if MIGRATION
namespace System.Windows.Controls.DataVisualization.Charting
#else
namespace Windows.UI.Xaml.Controls.DataVisualization.Charting
#endif
{
    /// <summary>
    /// Represents a data point used for a bar series.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [TemplateVisualState(Name = DataPoint.StateCommonNormal, GroupName = DataPoint.GroupCommonStates)]
    [TemplateVisualState(Name = DataPoint.StateCommonMouseOver, GroupName = DataPoint.GroupCommonStates)]
    [TemplateVisualState(Name = DataPoint.StateSelectionUnselected, GroupName = DataPoint.GroupSelectionStates)]
    [TemplateVisualState(Name = DataPoint.StateSelectionSelected, GroupName = DataPoint.GroupSelectionStates)]
    [TemplateVisualState(Name = DataPoint.StateRevealShown, GroupName = DataPoint.GroupRevealStates)]
    [TemplateVisualState(Name = DataPoint.StateRevealHidden, GroupName = DataPoint.GroupRevealStates)]
    public partial class BarDataPoint : DataPoint
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes the static members of the BarDataPoint class.
        /// </summary>
        static BarDataPoint()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarDataPoint), new FrameworkPropertyMetadata(typeof(BarDataPoint)));
        }

#endif
        /// <summary>
        /// Initializes a new instance of the BarDataPoint class.
        /// </summary>
        public BarDataPoint()
        {
#if SILVERLIGHT
            this.DefaultStyleKey = typeof(BarDataPoint);
#endif
        }
    }
}