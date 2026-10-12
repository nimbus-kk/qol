#!/bin/bash
set -euo pipefail

if [[ -f "configuration.props" ]]; then
    install_dir=$(sed -nE 's|^[[:space:]]*<KoboldKareInstallDir>(.*)</KoboldKareInstallDir>[[:space:]]*$|\1|p' configuration.props)

    if [[ -d "$install_dir" ]]; then
        dotnet build

        cd "$install_dir"
        ./run_bepinex.sh -force-glcore
    else
        echo "Please set KoboldKareInstallDir to the directory of your KoboldKare install, then run this script again."
    fi
else
    cp configuration.props.example configuration.props

    echo "Created configuration.props."
    echo "Please set KoboldKareInstallDir to the directory of your KoboldKare install, then run this script again."
fi