import os
import re

ASSEMBLY_INFO_FILE = 'Properties\AssemblyInfo.cs'
VERSION_INFO_FILE = 'versioninfo.txt'


def cd_script_dir():
    os.chdir(os.path.dirname(os.path.realpath(__file__)))


def get_version_file():
    with open(VERSION_INFO_FILE, 'r') as version_file:
        version_string = version_file.read()

    ind = version_string.find('-')

    only_ver = version_string[:ind]

    return only_ver


def main():
    cd_script_dir()

    os.system('git describe --long --dirty --always > {0}'.format(VERSION_INFO_FILE))

    print('git command complete')

    version = get_version_file()

    with open(ASSEMBLY_INFO_FILE, 'r') as assembly:
        assembly_data = assembly.read()

    updated_assembly = re.sub(r'(\[\s*assembly\s*:\s*AssemblyVersion\s*\(\s*\")([^\"]*)(\"\s*\)\s*\])',
                              r'\g<1>{0}\g<3>'.format(version),
                              assembly_data)

    if updated_assembly != assembly_data:
        with open(ASSEMBLY_INFO_FILE, 'w') as assembly:
            assembly.write(updated_assembly)


main()
