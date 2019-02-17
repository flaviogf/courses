#!/usr/local/bin/python3

import pdb
import zipfile
import os


def backup(folder):
    folder = os.path.abspath(folder)
    number = 1
    while True:
        zip = f'{os.path.basename(folder)}_{number}.zip'

        if not os.path.exists(zip):
            break

        number += 1

    backup_zip = zipfile.ZipFile(zip, 'w')

    for foldername, subfolders, files in os.walk(folder):
        backup_zip.write(foldername)

        for file in files:
            newBase = os.path.basename(folder) + '_'
            if file.startswith(newBase) and file.endswith('.zip'):
                continue

            backup_zip.write(os.path.join(foldername, file))

    backup_zip.close()


if __name__ == '__main__':
    backup('/Users/flavio/Downloads')
