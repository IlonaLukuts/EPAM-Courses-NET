using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IGiftItem
    {
        int Id { get; }
        string Name { get; }
        string Producer { get; }
        double Weight { get; }
        decimal Price { get; }
    }
}
