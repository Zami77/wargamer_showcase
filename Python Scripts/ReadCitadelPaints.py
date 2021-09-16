import json
import jsonpickle
import CreateListOfAllPaints

def create_citadel_paint(paint_chunk):
    newPaint = CreateListOfAllPaints.Paint()
    newPaint.id = newPaint.paint_name = paint_chunk["Paint name"]
    newPaint.company = "New Citadel"
    newPaint.hex_color = paint_chunk["Hex colour"]
    newPaint.category = "paints"
    return newPaint

def main():
    filename = "citadel_paints.json"
    finished_file = "ListOfAllCitadel.json"
    input_file = open(filename)
    all_citadel_paints = json.load(input_file)
    final_citadel_paints = []

    for paint_chunk in all_citadel_paints:
        final_citadel_paints.append(create_citadel_paint(paint_chunk))

    with open(finished_file, 'w') as f:
        f.write(jsonpickle.encode(final_citadel_paints, unpicklable=False))
    
    print("Converted ", len(final_citadel_paints), " Citadel paint(s) to JSON!")

if __name__ == "__main__":
    main()