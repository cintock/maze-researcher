import os
import re

ASSEMBLY_INFO_FILE = 'Properties\AssemblyInfo.cs'
VERSION_INFO_FILE = 'versioninfo.txt'


def current_dir_set_script_dir():
    os.chdir(os.path.dirname(os.path.realpath(__file__)))


def get_version_from_file():
    four_number_ver = None

    with open(VERSION_INFO_FILE, 'r') as version_file:
        version_string = version_file.read()

    ind = version_string.find('-')

    if ind > 0:
        only_ver = version_string[:ind]

        if re.match(r'[0-z]\.[0-z]\.[0-z]\.[0-z]$', only_ver) is not None:
            four_number_ver = only_ver

    return four_number_ver


def update_assembly(version):
    with open(ASSEMBLY_INFO_FILE, 'r') as assembly_file:
        assembly_data = assembly_file.read()

    updated_assembly = re.sub(r'(\[\s*assembly\s*:\s*AssemblyVersion\s*\(\s*\")([^\"]*)(\"\s*\)\s*\])',
                              r'\g<1>{0}\g<3>'.format(version),
                              assembly_data)

    if updated_assembly != assembly_data:
        with open(ASSEMBLY_INFO_FILE, 'w') as assembly_file:
            assembly_file.write(updated_assembly)


def main():
    current_dir_set_script_dir()

    os.system('git describe --long --dirty > "{0}"'.format(VERSION_INFO_FILE))

    version = get_version_from_file()

    if version is not None:
        update_assembly(version)


main()
