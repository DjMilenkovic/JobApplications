using JobApplications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.Repository
{
    public class DummyRepository : IRepository<Candidate>
    {
        private List<Candidate> Candidates;

        public DummyRepository()
        {
            Candidates = new List<Candidate>();

            Candidate candidate1 = new Candidate("Petar", "Petrovic", 3);
            candidate1.Zeljena_Plata = 22000;
            Candidates.Add(candidate1);

            Candidate candidate2 = new Candidate("Marko", "Petrovic", 5);
            candidate2.Zeljena_Plata = 23000;
            Candidates.Add(candidate2);

            Candidate candidate3 = new Candidate("Boris", "Petrovic", 1);
            candidate3.Zeljena_Plata = 21000;
            Candidates.Add(candidate3);

            Candidate candidate4 = new Candidate("Stefa", "Petrovic", 6);
            candidate4.Zeljena_Plata = 22000;
            Candidates.Add(candidate4);

            Candidate candidate5 = new Candidate("Djordje", "Petrovic", 8);
            candidate5.Zeljena_Plata = 22500;
            Candidates.Add(candidate5);

            Candidate candidate6 = new Candidate("Bojan", "Petrovic", 7);
            candidate6.Zeljena_Plata = 21500;
            Candidates.Add(candidate6);

            Candidate candidate7 = new Candidate("Milos", "Petrovic", 5);
            candidate7.Zeljena_Plata = 23000;
            Candidates.Add(candidate7);

            Candidate candidate8 = new Candidate("Ivan", "Petrovic", 4);
            candidate8.Zeljena_Plata = 24000;
            Candidates.Add(candidate8);

            Candidate candidate9 = new Candidate("Janko", "Petrovic", 10);
            candidate9.Zeljena_Plata = 22500;
            Candidates.Add(candidate9);

            Candidate candidate10 = new Candidate("Aca", "Petrovic", 6);

            Candidates.Add(candidate10);
        }
        

        public ICollection<Candidate> GetData()
        {            
            return GetSortedCandidatesBubbleSort(Candidates);
        }

        private ICollection<Candidate> GetSortedCandidatesLINQ(ICollection<Candidate> Candidates)
        {
            var SortedCandidates = (from can in Candidates
                                    where can.Godine_Iskustva >= 3
                                    orderby can.Zeljena_Plata.HasValue descending, can.Zeljena_Plata, can.Datum_Prijave
                                    select can).ToList();
            return SortedCandidates;
        }

        private ICollection<Candidate> GetSortedCandidatesBubbleSort(ICollection<Candidate> Candidates)
        {
            var candidates = Candidates.ToList();

            for (int i = 0; i < candidates.Count; i++)
            {
                for (int j = 0; j < candidates.Count - i - 1; j++)
                {
                    if (candidates[j].Godine_Iskustva < 3)
                    {
                        candidates.RemoveAt(j);
                        break;
                    }
                    if ((candidates[j].Zeljena_Plata > candidates[j + 1].Zeljena_Plata) || ((candidates[j].Zeljena_Plata == candidates[j + 1].Zeljena_Plata) && (candidates[j].Datum_Prijave > candidates[j + 1].Datum_Prijave)))
                    {
                        var temp = candidates[j];
                        candidates[j] = candidates[j + 1];
                        candidates[j + 1] = temp;
                    }
                }
            }
            return candidates;
        }
    }
}