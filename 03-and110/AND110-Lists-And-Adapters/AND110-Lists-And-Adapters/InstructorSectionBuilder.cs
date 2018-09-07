using System;
using System.Linq;
using System.Collections.Generic;

namespace AND110ListsAndAdapters
{
    public class InstructorSectionBuilder
    {
        private class SectionInfo
        {
            public string SectionTitle { get; internal set; }
            public int SectionIndex { get; internal set; }
            public int FirstIndexOf { get; internal set; }
            public int LastIndexOf { get; internal set; }
        }

        private readonly IList<Instructor> instructors;
        private readonly List<SectionInfo> sectionInfo;
        private readonly Dictionary<int, int> positionToSectionIndexMap;

        public InstructorSectionBuilder(IList<Instructor> instructors)
        {
            this.instructors = instructors;
            this.sectionInfo = instructors
                .Select((x, index) => new { FirstCharacter = x.Name[0], IndexOf = index })
                .GroupBy(x => x.FirstCharacter)
                .Select((x, index) =>
                    new SectionInfo
                    {
                        SectionTitle = x.Key.ToString(),
                        SectionIndex = index,
                        FirstIndexOf = x.Min(i => i.IndexOf),
                        LastIndexOf = x.Max(i => i.IndexOf)
                    })
                .ToList();

            Sections = sectionInfo
                .Select(x => (Java.Lang.Object)x.SectionTitle)
                .ToArray();

            positionToSectionIndexMap = new Dictionary<int, int>();
            for (var positionIndex = 0; positionIndex < instructors.Count; positionIndex++)
            {
                var sectionIndex = sectionInfo.First(x => positionIndex >= x.FirstIndexOf && positionIndex <= x.LastIndexOf).SectionIndex;
                positionToSectionIndexMap.Add(positionIndex, sectionIndex);
            }

                //new Java.Lang.Object[sectionInfo.Count];



        }

        public Java.Lang.Object[] Sections { get; }

        public int GetPositionForSection(int sectionIndex)
        {
            return sectionInfo[sectionIndex].FirstIndexOf;
        }

        public int GetSectionForPosition(int position)
        {
            return positionToSectionIndexMap[position];
        }
    }
}
