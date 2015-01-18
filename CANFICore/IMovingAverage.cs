using System;
using System.Collections.Generic;
using System.Text;

namespace Clifton.Tools.Data
{
	public interface IMovingAverage
	{
		double Average { get;}

		void AddSample(double val);
		void ClearSamples();
		void InitializeSamples(double val);
	}
}
