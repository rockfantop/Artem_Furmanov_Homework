using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homework1OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = @"Text:fi.....le.txt(6B);Some string content
Image:img.bmp(19MB);1920x1080
Text:data.txt(12B);Another string
Text:data1.txt(7B);Yet another string
Movie:logan.2017.mkv(19GB);1920х1080;2h12m
Image:vasya.png(4MB);123x342
Image:zemelya(14GB);124x124
Movie:ZyablikTheChosen.mkv(100GB);1600х1400;2h30m ";

            Parser parser = new Parser();
            parser.AddFileParser(new TextFileParser());
            parser.AddFileParser(new ImageFileParser());
            parser.AddFileParser(new MovieFileParser());

            TextController controller = new TextController();
            controller.PrintFiles(parser.ParseFileText(input));

        }
    }
}
