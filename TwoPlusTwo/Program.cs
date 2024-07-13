using System.Security.Cryptography;

namespace TwoPlusTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Variable O = new Variable(new List<int> { 2, 3, 4, 5, 6, 7, 8 });
            Variable R = new Variable(new List<int> { 2, 4, 6, 8, 0 });
            Variable W = new Variable(new List<int> { 0, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable U = new Variable(new List<int> { 0, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable F = new Variable(new List<int> { 1 });
            Variable T = new Variable(new List<int> { 6, 7, 8, 9 });
            Variable C1 = new Variable(new List<int> { 0, 1 });
            Variable C2 = new Variable(new List<int> { 0, 1 });
            Variable C3 = new Variable(new List<int> {1});

            Variable[] variables = new Variable[] {O, R, W, U, F, T, C1, C2, C3}

            List<Constrants> constrants = new List<Constrants>();
            constrants.Add(new Constrants(new List<char>() { 'O', 'R', '1' }, (List<int> values) => { return values[0] * 2 = values[1] + values[2] * 10; });
            constrants.Add(new Constrants(new List<char>() { 'W', '1', 'U', '2' }, (List<int> values) => { return values[0] * 2 + values[1] = values[2] + values[3] * 10; });
            constrants.Add(new Constrants(new List<char>() { 'T', '2', 'O', 'F' }, (List<int> values) => { return values[0] * 2 + values[1] = values[2] + values[3] * 10; });
            constrants.Add(new Constrants(new List<char>() { 'T', 'W' }, (List<int> values) => { return values[0] != values[1]; });
            constrants.Add(new Constrants(new List<char>() { 'W', 'O' }, (List<int> values) => { return values[0] != values[1]; });
            constrants.Add(new Constrants(new List<char>() { 'O', 'F' }, (List<int> values) => { return values[0] != values[1]; });
            constrants.Add(new Constrants(new List<char>() { 'F', 'U' }, (List<int> values) => { return values[0] != values[1]; });
            constrants.Add(new Constrants(new List<char>() { 'U', 'R' }, (List<int> values) => { return values[0] != values[1]; });
            constrants.Add(new Constrants(new List<char>() { 'F', '3' }, (List<int> values) => { return values[0] == values[1]; });

            Graph graph = new Graph();
            graph.AddNode(new GameState(new List<int>(), new List<char>(), domains, 'O');
        }
    }
}
