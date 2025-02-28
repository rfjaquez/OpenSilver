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
    /// An object that implements this interface requires a series host.
    /// </summary>
    public interface IRequireSeriesHost
    {
        /// <summary>
        /// Gets or sets the series host.
        /// </summary>
        ISeriesHost SeriesHost { get; set; }
    }
}