using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job
        Job job1 = new Job();
        job1._jobTitle = "English Teacher";
        job1._company = "Global Academy";
        job1._startYear = 2024;
        job1._endYear = 2025;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "Data Analyst";
        job2._company = "Jhalex Solutions";
        job2._startYear = 2020;
        job2._endYear = 2022;

        // Create resume and add jobs
        Resume myResume = new Resume();
        myResume._name = "Jhon Tobar";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.Display();
    }
}