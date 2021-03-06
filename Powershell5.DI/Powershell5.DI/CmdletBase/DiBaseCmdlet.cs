﻿// ***********************************************************************
// Assembly         : Powershell5.Helpers
// Author           : joirwi
// Created          : 04-17-2019
//
// Last Modified By : joirwi
// Last Modified On : 04-17-2019
// ***********************************************************************
// <copyright file="DiBaseCmdlet.cs" company="UTM-Online">
//     Copyright ©  2019
// </copyright>
// <summary>The base class for use with cmdlets that want Dependance Injection and want to derive them selves from the Cmdlet Base Class</summary>
// ***********************************************************************

using System;
using System.Management.Automation;
using UTMO.Powershell5.DI.DI;

namespace UTMO.Powershell5.DI.CmdletBase
{
  /// <summary>
  ///   Class DiBaseCmdlet.
  ///   Implements the <see cref="System.Management.Automation.Cmdlet" />
  /// </summary>
  /// <seealso cref="System.Management.Automation.Cmdlet" />
  public abstract class DiBaseCmdlet : Cmdlet
  {
    protected virtual void CmdletPreProcessor()
    {
    }

    /// <summary>
    ///   This method replaces the call you would make to the "BeginProcessing" method on the <see cref="PSCmdlet" /> class.
    /// </summary>
    protected virtual void BeginCmdletProcessing()
    {
    }

    /// <summary>
    ///   Overrides the BeginProcessing method from the base class.  In this method we perform the act of injection
    ///   dependencies in to properties and fields
    ///   decorated with the <see cref="ShouldInjectAttribute" />.
    /// </summary>
    protected sealed override void BeginProcessing()
    {
      this.CmdletPreProcessor();

      this.PerformFieldInjection<ShouldInjectAttribute>();

      this.BeginCmdletProcessing();
    }

    /// <summary>
    ///   This method replaces the call you would make to the "EndProcessing" method on the <see cref="PSCmdlet" /> class.
    /// </summary>
    protected virtual void EndCmdletProcessing()
    {
    }

    /// <summary>
    ///   Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a
    ///   uniform naming convention for class
    ///   methods
    /// </summary>
    protected sealed override void EndProcessing()
    {
      this.EndCmdletProcessing();
    }

    /// <summary>
    ///   This method replaces the call you would make to the "ProcessRecord" method on the <see cref="PSCmdlet" /> class.
    /// </summary>
    protected virtual void ProcessCmdletRecord()
    {
    }

    /// <summary>
    ///   Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a
    ///   uniform naming convention for class
    ///   methods
    /// </summary>
    protected sealed override void ProcessRecord()
    {
      this.ProcessCmdletRecord();
    }

    /// <summary>
    ///   This method replaces the call you would make to the "StopProcessing" method on the <see cref="PSCmdlet" /> class.
    /// </summary>
    protected virtual void StopCmdletProcessing()
    {
    }

    /// <summary>
    ///   Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a
    ///   uniform naming convention for class
    ///   methods
    /// </summary>
    protected override void StopProcessing()
    {
      this.StopCmdletProcessing();
    }

    /// <summary>
    ///   This class is used to decorate properties and fields that require dependency injection.
    ///   This class cannot be inherited.
    ///   Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.GenericParameter | AttributeTargets.Property)]
    protected sealed class ShouldInjectAttribute : Attribute, IShouldInject
    {
      /// <summary>
      ///   Initializes a new instance of the <see cref="ShouldInjectAttribute" /> class.
      /// </summary>
      public ShouldInjectAttribute()
      {
      }

      /// <summary>
      ///   Initializes a new instance of the <see cref="ShouldInjectAttribute" /> class.
      /// </summary>
      /// <param name="name">The name.</param>
      public ShouldInjectAttribute(string name)
      {
        this.Name = name;
      }

      /// <summary>
      ///   Gets or sets the name.
      /// </summary>
      /// <value>The name specified for a registered type with the DI container that you want retrieved.</value>
      /// <remarks>This is useful only when you are using named dependencies in your container.</remarks>
      public string Name { get; set; }
    }
  }
}