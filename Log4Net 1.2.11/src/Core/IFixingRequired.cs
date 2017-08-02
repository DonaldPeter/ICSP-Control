#region Apache License
//
// Licensed to the Apache Software Foundation (ASF) under one or more 
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership. 
// The ASF licenses this file to you under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with 
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;

namespace Log4Net.Core
{
	/// <summary>
	/// Interface for objects that require fixing.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Interface that indicates that the object requires fixing before it
	/// can be taken outside the context of the appender's 
	/// <see cref="Log4Net.Appender.IAppender.DoAppend"/> method.
	/// </para>
	/// <para>
	/// When objects that implement this interface are stored 
	/// in the context properties maps <see cref="Log4Net.GlobalContext"/>
	/// <see cref="Log4Net.GlobalContext.Properties"/> and <see cref="Log4Net.ThreadContext"/>
	/// <see cref="Log4Net.ThreadContext.Properties"/> are fixed 
	/// (see <see cref="LoggingEvent.Fix"/>) the <see cref="GetFixedObject"/>
	/// method will be called.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public interface IFixingRequired
	{
		/// <summary>
		/// Get a portable version of this object
		/// </summary>
		/// <returns>the portable instance of this object</returns>
		/// <remarks>
		/// <para>
		/// Get a portable instance object that represents the current
		/// state of this object. The portable object can be stored
		/// and logged from any thread with identical results.
		/// </para>
		/// </remarks>
		object GetFixedObject();
	}
}
