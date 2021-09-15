import json
from typing import final
import jsonpickle

class Paint:
    id = ""
    paint_name = ""
    company = ""
    hex_color = ""
    category = "paints"

def create_paints(paint_chunk):
    companies = ["New Citadel", "Old Citadel", "Vallejo Game Color", "Vallejo Model Color", "INSTAR", 
        "INSTAR Vintage", "Rackham", "Reaper Master", "Privateer Press", "Coat D'arms", "Army Painter",
        "Scale"]
    paints_added = []
    for comp in companies:
        if paint_chunk[comp] != "":
            newPaint = Paint()
            newPaint.id = newPaint.paint_name = paint_chunk[comp]
            newPaint.company = comp
            newPaint.hex_color = paint_chunk["Hex Code"]
            newPaint.category = "paints"
            paints_added.append(newPaint)
    return paints_added

def make_json_chunks(final_paints, filename):
    count = 0
    fileset = 1
    chunk_size = 350
    while count < len(final_paints):
        innerCount = 0
        with open(filename + str(fileset) + ".json", 'w') as f:
            f.write('[')
            while innerCount < chunk_size and count < len(final_paints):
                f.write(jsonpickle.encode(final_paints[count], unpicklable=False))
                count = count + 1
                innerCount = innerCount + 1
                if innerCount != chunk_size and count != len(final_paints):
                    f.write(',')
            f.write(']')
        fileset = fileset + 1

def main():
    filename = "PaintChart.json"
    finished_file = "ListOfAllPaints.json"
    input_file = open (filename)
    all_paints = json.load(input_file)
    final_paints = []

    for paint_chunk in all_paints:
        paints_to_add = create_paints(paint_chunk)
        for paint in paints_to_add:
            final_paints.append(paint)

    with open(finished_file, 'w') as f:
        f.write(jsonpickle.encode(final_paints, unpicklable=False))
    
    make_json_chunks(final_paints, "ListOfPaintsChunk_")

    print("Converted ", len(final_paints), " paint(s) to JSON!")

if __name__ == "__main__":
    main()