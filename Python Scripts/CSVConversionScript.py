import csv
import json

def make_json(csvFilePath, jsonFilePath):

    data = []

    with open(csvFilePath, encoding='utf-8') as csvf:
        csvReader = csv.DictReader(csvf)

        for row in csvReader:
            data.append(row)

    with open(jsonFilePath, 'w', encoding='utf-8') as jsonf:
        jsonString = json.dumps(data, indent=4)
        jsonf.write(jsonString)

def main():
    print("Converting csv to json")
    filename = input("Enter filename without extension: ")

    csvFilePath = r'{}.csv'.format(filename)
    jsonFilePath = r'{}.json'.format(filename)

    make_json(csvFilePath, jsonFilePath)

if __name__ == "__main__":
    main()